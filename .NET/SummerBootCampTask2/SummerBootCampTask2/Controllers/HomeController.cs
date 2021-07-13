using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SummerBootCampTask2.Contexts;
using SummerBootCampTask2.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SummerBootCampTask2.Controllers
{
    public class HomeController : Controller
    {
        private readonly BootCampDbContext dbContext;

        public HomeController(BootCampDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var models = new List<ConfirmRequestViewModel>();
            if (User.Identity.IsAuthenticated)
            {
                var users = dbContext.Users.ToList();

                var user = users.FirstOrDefault(x => x.Email == User.Identity.Name);
                
                if (user is null)
                {
                    return NotFound();
                }

                var requests = dbContext.UserFriends.Where(x => x.FriendId == user.Id && !x.IsVerified);

                foreach (var request in requests)
                {
                    var requestedUser = users.FirstOrDefault(x => x.Id == request.UserId);

                    models.Add(new ConfirmRequestViewModel
                    {
                        Id = requestedUser.Id,
                        UserName = requestedUser.UserName,
                    });
                }
            }
            return View(models);
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
