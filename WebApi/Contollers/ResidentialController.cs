using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer;
using RealtService.Application.Offers.ResidentialOffers.Commands.DeleteCommand;
using RealtService.Application.Offers.ResidentialOffers.Commands.UpdateOffer;
using RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferDetails;
using RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferList;
using RealtService.WebApi.Models;

namespace RealtService.WebApi.Controllers
{
    [Route("api/offers/[controller]")]
    public class ResidentialOfferController : RealtServiceControllerBase
    {
        public ResidentialOfferController(IMediator mediator, IMapper mapper): base(mediator, mapper) { }
        
        [HttpGet]
        public async Task<ActionResult<OfferListVm>> GetAll()
        {
            var query = new GetOfferListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDetailsVm>> Get(int id)
        {
            var query = new GetOfferDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateOfferDto createOfferDto)
        {
            var command = Mapper.Map<CreateResidentialOfferCommand>(createOfferDto);
            var offerId = await Mediator.Send(command);
            return Ok(offerId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOfferDto updateOfferDto)
        {
            var command = Mapper.Map<UpdateOfferCommand>(updateOfferDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOfferCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

