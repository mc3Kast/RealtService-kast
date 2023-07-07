using AutoMapper;
using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateResidentialOfferCommand, ResidentialOffer>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateOfferCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResidentialOffer> Handle(CreateResidentialOfferCommand request, CancellationToken cancellationToken)
        {
            ResidentialOffer offer = _mapper.Map<ResidentialOffer>(request);
            IRepository<ResidentialOffer> repository = _unitOfWork.ResidentialOffers;
            offer = repository.Insert(offer);
            await _unitOfWork.SaveChangesAsync();
            return offer;
        }
    }
}
