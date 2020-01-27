using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryKnikker.Core.DAL.Data;
using KnikkerShop.Models;
using Microsoft.AspNetCore.Authentication;

namespace KnikkerShop.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<BaseAccount> _userManager;
        private readonly SignInManager<BaseAccount> _signInManager;

        public LoginController(UserManager<BaseAccount> userManager, SignInManager<BaseAccount> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registreer(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (returnUrl == null)
                        returnUrl = "Home";
                    return RedirectToAction("Index", returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registreer(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                BaseAccount baseaccount = new BaseAccount(-1, model.Naam, model.Email)
                {
                    Postcode = model.Postcode,
                    Huisnummer = model.Huisnummer
                };
                var result = await _userManager.CreateAsync(baseaccount, model.Password);
                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(baseaccount, isPersistent: false);
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Aangemaakt", "Login");
                }
                ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
            }
            return RedirectToAction("Mislukt", "Login");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Logout), "Home");
        }

        //AccessDenied
        public IActionResult Aangemaakt()
        {
            return View();
        }

        public IActionResult Mislukt()
        {
            return View();
        }
    }
}