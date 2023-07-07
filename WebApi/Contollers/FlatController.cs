using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Estates.ResidentialEstates.Flats.Commands.CreateFlat;
using RealtService.Application.Estates.ResidentialEstates.Flats.Commands.UpdateFlat;
using RealtService.Application.Estates.ResidentialEstates.Flats.Queries.GetEstateList;
using RealtService.WebApi.Controllers;

namespace RealtService.WebApi.Contollers
{
    [Route("api/estates/residential/[controller]")]
    public class FlatController : RealtServiceControllerBase
    {
        public FlatController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<ActionResult<FlatListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetFlatListQuery { }));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create( CreateFlatCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update( UpdateFlatCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
