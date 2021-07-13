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
            return View(dbContext.Users.ToList());
        }
    }
}
