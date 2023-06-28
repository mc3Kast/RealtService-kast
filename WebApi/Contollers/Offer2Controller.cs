using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Offers.Queries.GetOfferList;
using RealtService.WebApi.Controllers;

namespace RealtService.WebApi.Contollers
{
    [Route("api/[controller]")]
    public class Offer2Controller : BaseController
    {
        private readonly IMapper _mapper;
        public Offer2Controller(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var query = new GetOfferListQuery
            //{
            //};
            //var vm = await Mediator.Send(query);
            return Ok(await Mediator.Send(new GetOfferListQuery { }));
        }
    }
}
