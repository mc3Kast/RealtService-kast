using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Users.Commands;
using RealtService.WebApi.Controllers;

namespace RealtService.WebApi.Contollers;

public class SignInController : RealtServiceControllerBase
{
    public SignInController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignIn(SignInCommand signInCommand)
    {
        //TODO: Sign in please JWT
        throw new NotImplementedException();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignOut(SignOutCommand signOutCommand)
    {
        //TODO: Sign out, clear token
        throw new NotImplementedException();
    }
}
