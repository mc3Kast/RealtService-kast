using RealtService.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RealtService.Application.Users.Queries.GetUserList;

namespace RealtService.WebApi.Contollers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetUserListQuery { }));
        }
    }
}
