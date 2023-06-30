using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Estates.CommercialEstates.Queries.GetEstateList;
using RealtService.WebApi.Controllers;

namespace RealtService.WebApi.Contollers
{
    [Route("api/estates/[controller]")]
    public class CommercialEstateController : RealtServiceControllerBase
    {
        public CommercialEstateController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<ActionResult<CommercialEstateListVm>> GetAll()
        {
            var query = new GetCommercialEstateListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
