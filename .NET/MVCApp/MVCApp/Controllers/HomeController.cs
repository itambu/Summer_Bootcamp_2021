using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApp.Contexts;
using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCAppDbContext dbContext;
        
        public HomeController(MVCAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            List<ConfirmRequestViewModel> ConfirmRequests = new List<ConfirmRequestViewModel>();

            var users = dbContext.Users.ToList();
            var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

            var requests = dbContext.UserFriends.Where(r => r.FriendId == user.Id && !r.isVerified);

            foreach (var request in requests)
            { 
                var requestedUser = users.FirstOrDefault(user => user.Id == request.UserId);
                ConfirmRequests.Add(new ConfirmRequestViewModel
                {
                    Id = request.UserId,
                    UserName = requestedUser.UserName,
                });
            }
            return View(ConfirmRequests);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
