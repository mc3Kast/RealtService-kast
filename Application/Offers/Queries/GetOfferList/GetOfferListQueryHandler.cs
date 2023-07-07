using AutoMapper;
using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Queries.GetOfferList
{
    public class GetOfferListQueryHandler : IRequestHandler<GetOfferListQuery, OfferListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetOfferListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
        public async Task<OfferListVm> Handle(GetOfferListQuery request, CancellationToken cancellationToken)
        {
            IRepository<Offer> offerRepository = _unitOfWork.Offers;
            IQueryable<Offer> offerQuery = await offerRepository
                .GetAllAsync();

            return new OfferListVm { Offers = offerQuery.ToList() };
        }
    }
}
