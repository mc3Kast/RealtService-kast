using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Queries.GetOfferDetails
{
    public class GetOfferDetailsQueryHandler : IRequestHandler<GetOfferDetailsQuery, OfferDetailsVm>
    {
        //private readonly IOfferDbContext _dbContext;
        //private readonly IMapper _mapper;
        //public GetOfferDetailsQueryHandler(IOfferDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        //public async Task<OfferDetailsVm> Handle(GetOfferDetailsQuery request, CancellationToken cancellationToken)
        //{
        //    var entity = await _dbContext.Offers.FirstOrDefaultAsync(offer => offer.Id == request.Id, cancellationToken);

        //    if (entity == null || request.UserId != entity.UserId)
        //    {
        //        throw new NotFoundException(nameof(Offer), request.Id);
        //    }

        //    return _mapper.Map<OfferDetailsVm>(entity);
        //}
        public Task<OfferDetailsVm> Handle(GetOfferDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
