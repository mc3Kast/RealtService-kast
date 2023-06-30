using AutoMapper;
using MediatR;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.ResidentialEstates.Queries.GetEstateList
{
    public class GetResidentialEstateListQueryHandler : IRequestHandler<GetResidentialEstateListQuery, ResidentialEstateListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetResidentialEstateListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
        public async Task<ResidentialEstateListVm> Handle(GetResidentialEstateListQuery request, CancellationToken cancellationToken)
        {
            IRepository<ResidentialEstate> estateRepository = _unitOfWork.ResidentialEstates;
            IQueryable<ResidentialEstate> estateQuery = await estateRepository
                .GetAllAsync();

            return new ResidentialEstateListVm { Estates = estateQuery.ToList() };
        }
    }
}
