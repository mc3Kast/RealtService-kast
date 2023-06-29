using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Offers.Commands.CreateOffer;
using RealtService.Application.Offers.Commands.DeleteCommand;
using RealtService.Application.Offers.Commands.UpdateOffer;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Application.Offers.Queries.GetOfferList;
using RealtService.Domain.Entities.Users;
using RealtService.WebApi.Models;

namespace RealtService.WebApi.Controllers
{
<<<<<<< HEAD
    [Route("api/offers")]
    public class OfferContoller : RealtServiceControllerBase
=======
    [Route("api/[controller]")]
    public class OfferController : RealtServiceControllerBase
>>>>>>> 7969b40e2b6c6596bb4c9b0f18af4cdb80a5146e
    {
        public OfferController(IMediator mediator, IMapper mapper): base(mediator, mapper) { }
        
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
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOfferDto createOfferDto)
        {
            var command = Mapper.Map<CreateOfferCommand>(createOfferDto);
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

