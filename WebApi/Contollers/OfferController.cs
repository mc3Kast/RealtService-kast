using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Offers.Commands.DeleteCommand;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Application.Offers.Queries.GetOfferList;
using RealtService.WebApi.Controllers;

namespace RealtService.WebApi.Contollers
{
    [Route("api/[controller]")]
    public class OfferController : RealtServiceControllerBase
    {
        public OfferController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<ActionResult<OfferListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetOfferListQuery { }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDetailsVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOfferDetailsQuery { Id = id}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteOfferCommand { Id = id});
            return NoContent();
        }
    }
}
