using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Offers.CommercialOffers.Commands.CreateOffer;
using RealtService.Application.Offers.CommercialOffers.Commands.UpdateOffer;
using RealtService.Application.Offers.CommercialOffers.Queries.GetOfferList;
using RealtService.WebApi.Controllers;
using RealtService.WebApi.Models;

namespace RealtService.WebApi.Contollers
{
    [Route("api/offers/[controller]")]
    public class CommercialOfferController : RealtServiceControllerBase
    {
        public CommercialOfferController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<ActionResult<CommercialOfferListVm>> GetAll()
        {
            var query = new GetOfferListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCommercialOfferDto createOfferDto)
        {
            var command = Mapper.Map<CreateCommercialOfferCommand>(createOfferDto);
            var offerId = await Mediator.Send(command);
            return Ok(offerId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommercialOfferDto updateOfferDto)
        {
            var command = Mapper.Map<UpdateCommercialOfferCommand>(updateOfferDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
