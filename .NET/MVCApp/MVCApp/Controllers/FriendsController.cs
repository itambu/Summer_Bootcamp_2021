using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Contexts;
using MVCApp.CoreModels;
using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {

        private readonly MVCAppDbContext dbContext;

        public FriendsController(MVCAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

            var relations = dbContext.UserFriends.Where(x => (x.UserId == user.Id || x.FriendId == user.Id) && (x.isVerified)).ToList();
            var users = dbContext.Users.ToList();
            var chats = dbContext.Chats.Where(c => c.FirstUserId == user.Id || c.SecondUserId == user.Id).ToList();

            List<FriendViewModel> models = new List<FriendViewModel>();

            foreach (var r in relations)
            {
                foreach (var u in users)
                {
                    if ((u.Id == r.UserId && user.Id == r.FriendId) || (u.Id == r.FriendId && user.Id == r.UserId))
                    {
                        var chat = chats.FirstOrDefault(c => c.FirstUserId == u.Id || c.SecondUserId == u.Id);
                        models.Add(new FriendViewModel
                        {
                            ChatId = chat.Id,
                            Friend = u,
                        });
                    }
                }
            }

            return View(models);
        }

        [HttpGet]
        public IActionResult RequestSent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendRequest(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

            var friend = dbContext.Users.FirstOrDefault(friend => friend.Id == id);

            if (user is null || friend is null)
            {
                return NotFound();
            }

            var relation = dbContext.UserFriends.FirstOrDefault(r => (r.FriendId == friend.Id && r.UserId == user.Id)
                                                                  || (r.FriendId == user.Id && r.UserId == friend.Id));
            if (relation is null)
            {
                dbContext.UserFriends.Add(new UserFriend
                {
                    UserId = user.Id,
                    FriendId = friend.Id,
                    isVerified = false,
                });
                dbContext.SaveChanges();

                return RedirectToAction("RequestSent", "Friends");
            }
            else
            {
                return RedirectToAction("Error", "Friends");
            }
        }

        [HttpGet]
        public IActionResult ConfirmRequest(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

            var friend = dbContext.Users.FirstOrDefault(friend => friend.Id == id);

            var relation = dbContext.UserFriends.FirstOrDefault(r => r.FriendId == user.Id && r.UserId == friend.Id);

            if (relation is null)
            {
                return BadRequest();
            }

            relation.isVerified = true;
            dbContext.SaveChanges();

            dbContext.Chats.Add(new Chat
            {
                FirstUserId = friend.Id,
                SecondUserId = user.Id,
            });
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult RemoveFriend(int? id)
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

            var relation = dbContext.UserFriends.FirstOrDefault(r => (r.FriendId == id && r.UserId == user.Id)
                                                                   || (r.UserId == id && r.FriendId == user.Id));
            if (relation is null)
            {
                return NotFound();
            }

            var chat = dbContext.Chats.FirstOrDefault(chat => (chat.FirstUserId == user.Id && chat.SecondUserId == id)
                                                           || (chat.FirstUserId == id && chat.SecondUserId == user.Id));

            dbContext.Chats.Remove(chat);
            dbContext.UserFriends.Remove(relation);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Friends");
        }
    }
}
