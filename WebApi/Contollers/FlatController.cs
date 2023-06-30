using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Estates.ResidentialEstates.Flats.Commands.CreateFlat;
using RealtService.Application.Estates.ResidentialEstates.Flats.Commands.UpdateFlat;
using RealtService.Application.Estates.ResidentialEstates.Flats.Queries.GetEstateList;
using RealtService.WebApi.Controllers;
using RealtService.WebApi.Models;

namespace RealtService.WebApi.Contollers
{
    [Route("api/estates/residential/[controller]")]
    public class FlatController : RealtServiceControllerBase
    {
        public FlatController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<ActionResult<FlatListVm>> GetAll()
        {
            var query = new GetFlatListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateFlatDto createOfferDto)
        {
            var command = Mapper.Map<CreateFlatCommand>(createOfferDto);
            var offerId = await Mediator.Send(command);
            return Ok(offerId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFlatDto updateOfferDto)
        {
            var command = Mapper.Map<UpdateFlatCommand>(updateOfferDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
