using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Contexts;
using MVCApp.Models;
using MVCApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly MVCAppDbContext dbContext;
        private readonly IEncryptionService encryptionService;

        public MessageController(MVCAppDbContext dbContext, IEncryptionService encryptionService)
        {
            this.dbContext = dbContext;
            this.encryptionService = encryptionService;
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);
            var msg = dbContext.Messages.FirstOrDefault(msg => msg.Id == id && msg.SenderId == user.Id);

            if (msg is null)
            {
                BadRequest();
            }

            return View(new EditMessageViewModel
            {
                Id = msg.Id,
                Data = encryptionService.Decrypt(msg, user.Key).Data,
            });
        }

        [HttpPost]
        public IActionResult Edit(EditMessageViewModel model)
        {

            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);
            var msg = dbContext.Messages.FirstOrDefault(msg => msg.Id == model.Id && msg.SenderId == user.Id);

            if (msg is null)
            {
                BadRequest();
            }

            msg.Data = model.Data;
            msg = encryptionService.Encrypt(msg, user.Key);
            msg.DateUpdate = DateTime.Now;
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Chat", new { id = msg.ChatId });
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);
            var msg = dbContext.Messages.FirstOrDefault(msg => msg.Id == id && msg.SenderId == user.Id);

            if (msg is null)
            {
                BadRequest();
            }

            dbContext.Messages.Remove(msg);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Chat", new { id = msg.ChatId });
        }
    }
}
