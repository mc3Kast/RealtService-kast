using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer;
using RealtService.Application.Offers.ResidentialOffers.Commands.UpdateOffer;
using RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferList;

namespace RealtService.WebApi.Controllers
{
    [Route("api/offers/[controller]")]
    public class ResidentialOfferController : RealtServiceControllerBase
    {
        public ResidentialOfferController(IMediator mediator, IMapper mapper): base(mediator, mapper) { }
        
        [HttpGet]
        public async Task<ActionResult<ResiadentialOfferListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetOfferListQuery { }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateResidentialOfferCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateResidentialOfferCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

    }
}

