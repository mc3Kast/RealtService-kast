using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Offers.Queries.GetOfferList
{
    public class GetOfferListQueryHandler : IRequestHandler<GetOfferListQuery, OfferListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetOfferListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
        public async Task<OfferListVm> Handle(GetOfferListQuery request, CancellationToken cancellationToken)
        {
            IRepository<Offer> offerRepository = _unitOfWork.GetRepository<Offer>()!;
            IQueryable<Offer> offerQuery = await offerRepository
                .GetAllAsync();
            
            return new OfferListVm { Offers =  offerQuery.ToList() };
        }
    }
}
