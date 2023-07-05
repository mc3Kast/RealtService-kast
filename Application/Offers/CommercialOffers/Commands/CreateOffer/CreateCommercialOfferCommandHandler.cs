using AutoMapper;
using MediatR;
using RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.CommercialOffers.Commands.CreateOffer
{
    public class CreateCommercialOfferCommandHandler : IRequestHandler<CreateCommercialOfferCommand, CommercialOffer>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCommercialOfferCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommercialOffer> Handle(CreateCommercialOfferCommand request, CancellationToken cancellationToken)
        {
            CommercialOffer offer = _mapper.Map<CommercialOffer>(request);
            
            IRepository<CommercialOffer> repository = _unitOfWork.CommercialOffers;
            offer = repository.Insert(offer);
            await _unitOfWork.SaveChangesAsync();
            return offer;
        }
    }
}
