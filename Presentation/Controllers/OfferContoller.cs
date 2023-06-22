using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Offers.Commands.CreateOffer;
using RealtService.Application.Offers.Commands.DeleteCommand;
using RealtService.Application.Offers.Commands.UpdateOffer;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Application.Offers.Queries.GetOfferList;
using RealtService.Presentation.Models;

namespace RealtService.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class OfferContoller : BaseController
    {
        private readonly IMapper _mapper;
        public OfferContoller(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<OfferListVm>> GetAll()
        {
            var query = new GetOfferListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDetailsVm>> Get(Guid id)
        {
            var query = new GetOfferDetailsQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOfferDto createOfferDto)
        {
            var command = _mapper.Map<CreateOfferCommand>(createOfferDto);
            command.UserId = UserId;
            var offerId = await Mediator.Send(command);
            return Ok(offerId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOfferDto updateOfferDto)
        {
            var command = _mapper.Map<UpdateOfferCommand>(updateOfferDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOfferCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
