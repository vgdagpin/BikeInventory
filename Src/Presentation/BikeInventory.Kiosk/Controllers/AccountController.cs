﻿using System.Security.Claims;

using BikeInventory.Kiosk.Common;
using BikeInventory.Kiosk.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BikeInventory.Kiosk.Controllers
{
    public class AccountController : Controller
    {
        private readonly BikeSignInManager p_SignInManager;
        private readonly BikeUserManager p_UserManager;

        public AccountController(BikeSignInManager signInManager, BikeUserManager userManager)
        {
            p_SignInManager = signInManager;
            p_UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, login.Username)
            });

            var user = await p_UserManager.GetUserAsync(new ClaimsPrincipal(identity));
            
            if (user == null)
            {
                return Unauthorized();
            }

            var result = await p_SignInManager.PasswordSignInAsync(user, login.Password, login.IsPersistent, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }, "Test"));

            await HttpContext.SignInAsync(principal);

            return Redirect("/");
        }
    }
}
