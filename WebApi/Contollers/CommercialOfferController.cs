using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Offers.CommercialOffers.Commands.CreateOffer;
using RealtService.Application.Offers.CommercialOffers.Commands.UpdateOffer;
using RealtService.Application.Offers.CommercialOffers.Queries.GetOfferList;
using RealtService.WebApi.Controllers;

namespace RealtService.WebApi.Contollers
{
    [Route("api/offers/[controller]")]
    public class CommercialOfferController : RealtServiceControllerBase
    {
        public CommercialOfferController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<ActionResult<CommercialOfferListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetOfferListQuery { }));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create(CreateCommercialOfferCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UpdateCommercialOfferCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
