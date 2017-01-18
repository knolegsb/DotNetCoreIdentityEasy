using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DotNetCoreIdentityEasy.Models;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreIdentityEasy.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;

        public HomeController(UserManager<MyIdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            MyIdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;

            ViewBag.Message = $"Welcome {user.FullName}!";

            if (userManager.IsInRoleAsync(user, "NormalUser").Result)
            {
                ViewBag.RoleMessage = "You are a NormalUser.";
            }
            return View();
        }
    }
}