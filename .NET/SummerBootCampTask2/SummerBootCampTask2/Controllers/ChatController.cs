using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerBootCampTask2.Contexts;
using SummerBootCampTask2.CoreModels;
using SummerBootCampTask2.Models;
using System.Linq;

namespace SummerBootCampTask2.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly BootCampDbContext dbContext;

        public ChatController(BootCampDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var users = dbContext.Users.ToList();

            var user = users.FirstOrDefault(user => user.Email == User.Identity.Name);
            var friend = users.FirstOrDefault(user => user.Id == id);

            if (user is null || friend is null)
            {
                return NotFound();
            }

            var userFriend = dbContext.UserFriends
                .FirstOrDefault(x => (x.UserId == user.Id || x.FriendId == friend.Id)
                                && (x.UserId == friend.Id || x.FriendId == friend.Id));

            if (userFriend is null)
            {
                return RedirectToAction("Invite", "Invitation", new { id = id });
            }

            var chat = dbContext.Chats.FirstOrDefault(x => (x.FirstUserId == user.Id || x.SecondUserId == friend.Id)
                                && (x.FirstUserId == friend.Id || x.SecondUserId == friend.Id));

            return View(new ChatViewModel
            {
                Id = chat.Id,
                FirstUserId = chat.FirstUserId,
                SecondUserId = chat.SecondUserId,
                Messages = dbContext.Messages.Where(x => x.ChatId == chat.Id),
                NewMessage = new Message(),
            });
        }
    }
}
