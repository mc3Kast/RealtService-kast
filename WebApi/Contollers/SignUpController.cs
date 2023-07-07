using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealtService.Domain.Entities.Users;
using RealtService.WebApi.Controllers;
using RealtService.WebApi.Models;

namespace RealtService.WebApi.Contollers;

[Route("api/[controller]")]
[ApiController]
public class SignUpController : RealtServiceControllerBase
{
    public SignUpController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

    [HttpPost]
    public async Task<IActionResult> CreateNewUser([FromBody] SignUpCommand createNewUserCommand)
    {
        User user = await Mediator.Send(createNewUserCommand);
        return Ok(new { user.Id, user.Email, user.UserName });
    }

}