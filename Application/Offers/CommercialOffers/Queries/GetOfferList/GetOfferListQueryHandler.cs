using AutoMapper;
using MediatR;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.CommercialOffers.Queries.GetOfferList
{
    public class GetOfferListQueryHandler : IRequestHandler<GetOfferListQuery, CommercialOfferListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetOfferListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
        public async Task<CommercialOfferListVm> Handle(GetOfferListQuery request, CancellationToken cancellationToken)
        {
            IRepository<CommercialOffer> offerRepository = _unitOfWork.CommercialOffers;
            IQueryable<CommercialOffer> offerQuery = await offerRepository
                .GetAllAsync();

            return new CommercialOfferListVm { Offers = offerQuery.ToList() };
        }
    }
}
