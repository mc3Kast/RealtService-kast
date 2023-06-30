using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer;
using RealtService.Application.Offers.ResidentialOffers.Commands.UpdateOffer;
using RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferList;
using RealtService.WebApi.Models;

namespace RealtService.WebApi.Controllers
{
    [Route("api/offers/[controller]")]
    public class ResidentialOfferController : RealtServiceControllerBase
    {
        public ResidentialOfferController(IMediator mediator, IMapper mapper): base(mediator, mapper) { }
        
        [HttpGet]
        public async Task<ActionResult<ResiadentialOfferListVm>> GetAll()
        {
            var query = new GetOfferListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateResidentialOfferDto createOfferDto)
        {
            var command = Mapper.Map<CreateResidentialOfferCommand>(createOfferDto);
            var offerId = await Mediator.Send(command);
            return Ok(offerId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateResidentialOfferDto updateOfferDto)
        {
            var command = Mapper.Map<UpdateOfferCommand>(updateOfferDto);
            await Mediator.Send(command);
            return NoContent();
        }

    }
}

