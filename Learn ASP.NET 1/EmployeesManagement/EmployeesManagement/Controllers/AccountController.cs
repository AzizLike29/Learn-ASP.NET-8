using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EmployeesManagement.Models;

namespace EmployeesManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    ViewBag.success = true;
                    await Task.Delay(3000);
					TempData["SweetAlertRegister"] = "success";
					return RedirectToAction("Login", "Account");
                }
				foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                await Task.Delay(1000);
                TempData["SweetAlertRegister"] = "error";
			}
            return View(model);
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
                var identityUser = await _userManager.FindByEmailAsync(model.Email);
                if (identityUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(identityUser, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        await Task.Delay(3000);
                        TempData["SweetAlertLogin"] = "success";
						return RedirectToAction("IndexHome", "Home");
                    }
                }
                await Task.Delay(1000);
                TempData["SweetAlertLogin"] = "error";
			}
            return View(model);
        }
    }
}