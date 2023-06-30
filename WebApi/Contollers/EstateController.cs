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
            var query = new GetEstateListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstateDetailsVm>> Get(int id)
        {
            var query = new GetEstateDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteEstateCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
