using RealtService.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RealtService.Application.Users.Queries.GetUserList;
using MediatR;

namespace RealtService.WebApi.Contollers
{
    public class UserController: RealtServiceControllerBase
    {
        public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new JsonResult(await Mediator.Send(new GetUserListQuery { }));
        }
    }
}
