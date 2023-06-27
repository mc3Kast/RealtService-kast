using Microsoft.AspNetCore.Mvc;
using RealtService.Identity.Models;
using RealtService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;
using RealtService.Application.Offers.Commands;

namespace RealtService.Identity.Controllers
{
    public class OfferManagmentController : Controller
    {
        private readonly UserManager<User> _offerManager;

        public OfferManagmentController(UserManager<User> offerManager) =>
            (_offerManager) = (offerManager);

        [HttpGet]
        public IActionResult CreateOffer(string returnUrl)
        {
            var viewModel = new OfferManagingModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(OfferManagingModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _offerManager.FindByNameAsync(viewModel.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Offer creator not found");
                return View(viewModel);
            }

            //Its no function for offer creation(or im blind). Need to write
            //Also need to write different creations for different types of estates or somehow else
            var result = await new CreateOfferCommand(viewModel.Term, viewModel.Description, viewModel.Email, viewModel.Estate);
            if (result.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Offer creation error");
            return View(viewModel);
        }
    }
}
