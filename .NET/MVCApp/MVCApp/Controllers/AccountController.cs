using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Contexts;
using MVCApp.CoreModels;
using MVCApp.Models;
using MVCApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace MVCApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly MVCAppDbContext dbContext;
        private readonly IEncryptionService encryptionService;

        public AccountController(MVCAppDbContext dbContext, IEncryptionService encryptionService)
        {
            this.dbContext = dbContext;
            this.encryptionService = encryptionService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.Users.FirstOrDefault(user => user.Email == model.Email && user.Password == encryptionService.GetHash(model.Password));

                if (user != null)
                {
                    await Authenticate(model.Email);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Password or Email!");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.Users.FirstOrDefault(user => user.Email == model.Email);

                if (user is null)
                {
                    Random random = new Random();
                    int Identifier = random.Next(10000, 99999);

                    while (true)
                    {
                        if (dbContext.Users.FirstOrDefault(user => user.Identifier == Identifier) != null)
                        {
                            Identifier = random.Next(10000, 99999);
                        }
                        else
                        {
                            break;
                        }
                    }

                    dbContext.Users.Add(new User
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        Password = encryptionService.GetHash(model.Password),
                        Key = random.Next(10),
                        Identifier = Identifier,
                        IsVisible = true,

                    });

                    dbContext.SaveChanges();

                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User already exists!");  
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


        private async Task Authenticate(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
