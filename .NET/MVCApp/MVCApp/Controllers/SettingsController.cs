using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Contexts;
using MVCApp.CoreModels;
using MVCApp.Models;
using MVCApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {

        private readonly MVCAppDbContext dbContext;
        private readonly IEncryptionService encryptionService;

        public SettingsController(MVCAppDbContext dbContext, IEncryptionService encryptionService)
        {
            this.dbContext = dbContext;
            this.encryptionService = encryptionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = dbContext.Users.FirstOrDefault(user => User.Identity.Name == user.Email);

            return View(new SettingsViewModel
            {
                UserName = user.UserName,
                Identifier = user.Identifier,
                IsVisible = user.IsVisible,
            });
        }

        [HttpPost]
        public IActionResult Index(SettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

                if (model.NewPassword == "" || model.NewPassword is null)
                {
                    user.UserName = model.UserName;
                    user.IsVisible = model.IsVisible;
                }
                else
                {
                    user.UserName = model.UserName;
                    user.Password = encryptionService.GetHash(model.NewPassword);
                    user.IsVisible = model.IsVisible;
                }

                dbContext.SaveChanges();

                return RedirectToAction("Success", "Settings");
            }
                return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }

    }
}
