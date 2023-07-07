using AutoMapper;
using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.CommercialEstates.Queries.GetEstateList
{
    public class GetCommercialEstateListQueryHandler : IRequestHandler<GetCommercialEstateListQuery, CommercialEstateListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCommercialEstateListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
        public async Task<CommercialEstateListVm> Handle(GetCommercialEstateListQuery request, CancellationToken cancellationToken)
        {
            IRepository<CommercialEstate> estateRepository = _unitOfWork.CommercialEstates;
            IQueryable<CommercialEstate> estateQuery = await estateRepository
                .GetAllAsync();

            return new CommercialEstateListVm { Estates = estateQuery.ToList() };
        }
    }
}
