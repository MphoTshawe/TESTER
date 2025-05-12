using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TESTER.Data;
using TESTER.Models;

namespace TESTER.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminAccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login() => View();




        [HttpPost]
        public async Task<IActionResult> Login(LoginVeiwModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            // Use the user's username for the login attempt
            var result = await _signInManager.PasswordSignInAsync(
                user.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Dashboard" , new { area = "Admin" }) ;

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }


    }
}
