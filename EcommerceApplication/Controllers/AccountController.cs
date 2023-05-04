using EcommerceApplication.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Net.Mail;

namespace EcommerceApplication.Controllers
{
  
    public class AccountController : Controller
    {
        private readonly IToastNotification toastNotification;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _RoleManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IToastNotification toastNotification)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _RoleManager = roleManager;
            this.toastNotification = toastNotification;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.Email = model.Email;
                user.UserName = new MailAddress(model.Email).User;
                IdentityResult Result = await _userManager.CreateAsync(user, model.Password);
                if (Result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in Result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                IdentityUser user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, false);
                    if (result.Succeeded)
                    {
                        if( await _userManager.IsInRoleAsync(user, "Admin"))
                        {
                            return RedirectToAction("Dashboard", "Category");

                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Password");
                    }
                }
                ModelState.AddModelError("", "Invalid UserName");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        //Create Amdin
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.Email = model.Email;
                user.UserName = new MailAddress(model.Email).User;
                IdentityResult Result= await _userManager.CreateAsync(user, model.Password);
                if (Result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    toastNotification.AddSuccessToastMessage("Added");
                    return RedirectToAction("Dashboard", "Category");

                }
                else
                {
                    foreach (var error in Result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

    }
}
