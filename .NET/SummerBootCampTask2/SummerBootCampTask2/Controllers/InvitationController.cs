using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerBootCampTask2.Contexts;
using SummerBootCampTask2.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerBootCampTask2.Controllers
{
    [Authorize]
    public class InvitationController : Controller
    {
        private readonly BootCampDbContext dbContext;

        public InvitationController(BootCampDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Invite(int? id)
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

            if (dbContext.UserFriends
                .Any(x => (x.UserId == user.Id || x.FriendId == friend.Id)
                                && (x.UserId == friend.Id || x.FriendId == friend.Id)))
            {
                return BadRequest();
            }

            dbContext.UserFriends.Add(new UserFriend
            {
                UserId = user.Id,
                FriendId = friend.Id,
                IsVerified = false,
            });
            dbContext.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult Confirm(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var user = dbContext.Users.FirstOrDefault(x => x.Email == User.Identity.Name);

            var request = dbContext.UserFriends.FirstOrDefault(x => x.UserId == id && x.FriendId == user.Id);
            request.IsVerified = true;
            dbContext.Chats.Add(new Chat
            {
                FirstUserId = user.Id,
                SecondUserId = id.Value,
            });
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
