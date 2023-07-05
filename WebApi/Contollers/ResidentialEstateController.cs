using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealtService.Application.Estates.ResidentialEstates.Queries.GetEstateList;
using RealtService.WebApi.Controllers;

namespace RealtService.WebApi.Contollers
{
    [Route("api/estates/[controller]")]
    public class ResidentialEstateController : RealtServiceControllerBase
    {
        public ResidentialEstateController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<ActionResult<ResidentialEstateListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetResidentialEstateListQuery { }));
        }
    }
}
