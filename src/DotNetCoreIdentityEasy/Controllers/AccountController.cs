using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreIdentityEasy.Models;
using Microsoft.AspNetCore.Identity;

namespace DotNetCoreIdentityEasy.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;
        private readonly SignInManager<MyIdentityUser> loginManager;
        private readonly RoleManager<MyIdentityRole> roleManager;

        public AccountController(UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> loginManager, RoleManager<MyIdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel regiModel)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = regiModel.UserName;
                user.Email = regiModel.Email;
                user.FullName = regiModel.FullName;
                user.BirthDate = regiModel.BirthDate;

                IdentityResult result = userManager.CreateAsync(user, regiModel.Password).Result;

                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync("NormalUser").Result)
                    {
                        MyIdentityRole role = new MyIdentityRole();
                        role.Name = "NormalUser";
                        role.Description = "Perform normal operations.";
                        IdentityResult roleResult = roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Error while creating role!");
                            return View(regiModel);
                        }
                    }
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();

                    return RedirectToAction("Login", "Account");
                }                
            }
            return View(regiModel);
        } 
        
        public IActionResult Login()
        {
            return View();
        }      
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel logModel)
        {
            if (ModelState.IsValid)
            {
                var result = loginManager.PasswordSignInAsync(logModel.UserName, logModel.Password, logModel.RememberMe, false).Result; 

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login!");
            }

            return View(logModel);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            loginManager.SignOutAsync().Wait();
            return RedirectToAction("Login", "Account");
        }
    }
}