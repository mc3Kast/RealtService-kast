using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Interfaces;
using RealtService.Application.Offers.Queries.GetOfferDetails;
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
        private readonly IOfferDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOfferListQueryHandler(IOfferDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<OfferListVm> Handle(GetOfferListQuery request, CancellationToken cancellationToken)
        {
            var offerQuery = await _dbContext.Offers
                .Where(offer => offer.UserId == request.UserId)
                .ProjectTo<OfferLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OfferListVm { Offers =  offerQuery };
        }
    }
}
