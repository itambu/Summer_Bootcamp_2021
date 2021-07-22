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
    public class UsersController : Controller
    {
        private readonly MVCAppDbContext dbContext;

        public UsersController(MVCAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

            var users = dbContext.Users.Where(x => x.Id != user.Id);

            var relationsNotFriends = dbContext.UserFriends.Where(r => (r.UserId == user.Id || r.FriendId == user.Id) && !r.isVerified).ToList();
            var relationsFriends = dbContext.UserFriends.Where(r => (r.UserId == user.Id || r.FriendId == user.Id) && r.isVerified).ToList();
            var relations = dbContext.UserFriends.Where(r => r.UserId == user.Id || r.FriendId == user.Id).ToList();

            List<UserViewModel> model = new List<UserViewModel>();
            
            foreach (var u in users)
            {
                if (!u.IsVisible) continue;
                int count = 0;

                foreach (var r in relations)
                {
                    if (r.UserId == u.Id || r.FriendId == u.Id) count++;
                }
                if (count == 0)
                {
                    model.Add(new UserViewModel
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        Email = u.Email,
                        isFriend = false,
                    });
                }
           
            }
            
            foreach (var rn in relationsNotFriends)
            {
                var notFriend = users.FirstOrDefault(notFriend => notFriend.Id == rn.FriendId || notFriend.Id == rn.UserId);

                if (!notFriend.IsVisible) continue;

                model.Add(new UserViewModel
                {
                    Id = notFriend.Id,
                    UserName = notFriend.UserName,
                    Email = notFriend.Email,
                    isFriend = false,
                });
            }

            foreach (var rn in relationsFriends)
            {
                var friend = users.FirstOrDefault(friend => friend.Id == rn.FriendId || friend.Id == rn.UserId);
                model.Add(new UserViewModel
                {
                    Id = friend.Id,
                    UserName = friend.UserName,
                    Email = friend.Email,
                    isFriend = true,
                });
            }

            return View(model);
        }
       

        [HttpGet]
        public IActionResult FindUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindUser(FindUserViewModel model)
        {
            var findUser = dbContext.Users.FirstOrDefault(user => user.Identifier == model.Identifier);

            if (findUser is null)
            {
                return View();
            }

            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

            if (user.Identifier == model.Identifier)
            {
                return View();
            }

            model = new FindUserViewModel
            {
                Id = findUser.Id,
                Identifier = findUser.Identifier,
                UserName = findUser.UserName,
                Email = findUser.Email,
            };

            var relation = dbContext.UserFriends.FirstOrDefault(r => ((r.UserId == user.Id && r.FriendId == findUser.Id)
                                                                        || (r.UserId == findUser.Id && r.FriendId == user.Id))
                                                                        && (r.isVerified));
            if (relation is null)
            {
                model.isFriend = false;
            }
            else
            {
                model.isFriend = true;
            }
        
            return View(model);
        }

    }
}
