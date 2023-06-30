using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace RealtService.WebApi.Controllers
{
    [ApiController]
    public abstract class RealtServiceControllerBase : ControllerBase
    {
        protected IMediator Mediator { get; }
        protected IMapper Mapper { get; }
        protected RealtServiceControllerBase(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }
    }
}
