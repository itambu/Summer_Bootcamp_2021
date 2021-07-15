using Microsoft.AspNetCore.Mvc;
using SummerBootCampTask2.Contexts;
using System.Linq;

namespace SummerBootCampTask2.Controllers
{
    public class UserController : Controller
    {
        private readonly BootCampDbContext dbContext;

        public UserController(BootCampDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var users = dbContext.Users.ToList();
            if (User.Identity.IsAuthenticated)
            {
                users = users.Where(x => x.Email != User.Identity.Name).ToList();
            }
            return View(users);
        }
    }
}
