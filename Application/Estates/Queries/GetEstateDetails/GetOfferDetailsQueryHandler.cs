using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;

namespace RealtService.Application.Estates.Queries.GetEstateDetails
{
    public class GetEstateDetailsQueryHandler : IRequestHandler<GetEstateDetailsQuery, EstateDetailsVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetEstateDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<EstateDetailsVm> Handle(GetEstateDetailsQuery request, CancellationToken cancellationToken)
        {
            IRepository<Offer> offerRepository = _unitOfWork.Offers;
            var entity = await offerRepository.GetFirstOrDefaulAsync(offer => offer.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

            return _mapper.Map<EstateDetailsVm>(entity);
        }
    }
}
