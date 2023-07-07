using AutoMapper;
using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.Queries.GetEstateList
{
    public class GetEstateListQueryHandler : IRequestHandler<GetEstateListQuery, EstateListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetEstateListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
        public async Task<EstateListVm> Handle(GetEstateListQuery request, CancellationToken cancellationToken)
        {
            IRepository<Estate> estateRepository = _unitOfWork.Estates;
            IQueryable<Estate> estateQuery = await estateRepository
                .GetAllAsync();

            return new EstateListVm { Estates = estateQuery.ToList() };
        }
    }
}
