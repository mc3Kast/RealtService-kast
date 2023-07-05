using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Estates.Commands.DeleteCommand;
using RealtService.Application.Estates.Queries.GetEstateDetails;
using RealtService.Application.Estates.Queries.GetEstateList;
using RealtService.WebApi.Controllers;

namespace RealtService.WebApi.Contollers
{
    [Route("api/[controller]")]
    public class EstateController : RealtServiceControllerBase
    {
        public EstateController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<ActionResult<EstateListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetEstateListQuery { }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstateDetailsVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetEstateDetailsQuery { Id = id}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEstateCommand { Id = id});
            return NoContent();
        }
    }
}
