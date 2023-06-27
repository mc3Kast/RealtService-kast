using Microsoft.AspNetCore.Mvc;
using RealtService.Identity.Models;
using RealtService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;

namespace RealtService.Identity.Controllers
{
    public class UserConditionController : Controller
    {
        private readonly RoleManager<User> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserConditionController
            (RoleManager<User> roleManager, UserManager<User> userManager) =>
            (_roleManager, _userManager) = (roleManager, userManager);

        [HttpGet]
        public IActionResult ChangeRole(string returnUrl)
        {
            var viewModel = new UserRoleModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(UserRoleModel viewModel)
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

            var result = await _roleManager.SetRoleNameAsync(user, viewModel.Role.ToString());
            if (result.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Update role error");
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult ChangeStatus(string returnUrl)
        {
            var viewModel = new UserStatusModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(UserStatusModel viewModel)
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

            //Its no function for status update(or im blind). Need to write
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Update status error");
            return View(viewModel);
        }
    }
}
