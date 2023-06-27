using Microsoft.AspNetCore.Mvc;
using RealtService.Identity.Models;
using RealtService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;

namespace RealtService.Identity.Controllers
{
    public class AuthController : Controller
    {
        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckUserType(string usertype)
        {
            if (usertype == "Owner" || usertype == "Agency")
                return Json(true);
            return Json(false);
        }

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;

        public AuthController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            IIdentityServerInteractionService interactionService) =>
            (_signInManager, _userManager, _interactionService) = 
            (signInManager, userManager, interactionService);

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                Email = returnUrl,
                Password = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByNameAsync(viewModel.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(viewModel.Email,
                viewModel.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Login error");
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var viewModel = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

           var user = new Owner
            {
                Email = viewModel.Email,
                HashPassword = viewModel.Password
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);            
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout (string logoutid)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutid);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }   
}
