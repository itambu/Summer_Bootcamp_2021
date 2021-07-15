using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerBootCampTask2.Contexts;
using SummerBootCampTask2.Models;
using SummerBootCampTask2.Services;
using System.Linq;

namespace SummerBootCampTask2.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly BootCampDbContext dbContext;
        private readonly IEncryptionService encryptionService;

        public MessageController(BootCampDbContext dbContext, IEncryptionService encryptionService)
        {
            this.dbContext = dbContext;
            this.encryptionService = encryptionService;
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);
            var message = dbContext.Messages.FirstOrDefault(message => message.Id == id);

            if (message is null || user is null || message.SenderId != user.Id)
            {
                return NotFound();
            }

            dbContext.Messages.Remove(message);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Chat", new { id = message.RecipientId });
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var message = dbContext.Messages.FirstOrDefault(x => x.Id == id);
            var user = dbContext.Users.FirstOrDefault(x => x.Email == User.Identity.Name);
            if (message is null || message.SenderId != user.Id)
            {
                return NotFound();
            }

            return View(new EditMessageViewModel
            {
                Id = message.Id,
                Message = encryptionService.Decrypt(message, user.Key).Data,
            });
        }

        [HttpPost]
        public IActionResult Edit(EditMessageViewModel model)
        {

            var message = dbContext.Messages.FirstOrDefault(x => x.Id == model.Id);
            message.Data = model.Message;
            var user = dbContext.Users.FirstOrDefault(x => x.Email == User.Identity.Name);

            encryptionService.Encrypt(message, user.Key);

            dbContext.SaveChanges();

            return RedirectToAction("Index", "Chat", new { id = message.RecipientId });
        }
    }
}
