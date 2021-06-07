using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using Catering.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork DB;

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(IUnitOfWork db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            DB = db;

            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("Model is not valid!");
            }

            User user = DB.UserRepository.Get(loginModel.Username);

            if(user != null)
            {
                var passwordIsOk = await userManager.CheckPasswordAsync(user, loginModel.Password);

                if (!passwordIsOk)
                {
                    return Content("Username or password is incorrect");
                }
            }
            else
            {
                return Content("Unername or password is incorrect");
            }

            var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, true, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Chief");
            }
            else
            {
                return BadRequest("Username or password is incorrect");
            }
        }
    }
}
