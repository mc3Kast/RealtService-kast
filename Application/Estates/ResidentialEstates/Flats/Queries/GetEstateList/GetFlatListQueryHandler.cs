using AutoMapper;
using MediatR;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Queries.GetEstateList
{
    public class GetFlatListQueryHandler : IRequestHandler<GetFlatListQuery, FlatListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetFlatListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
        public async Task<FlatListVm> Handle(GetFlatListQuery request, CancellationToken cancellationToken)
        {
            IRepository<Flat> estateRepository = _unitOfWork.Flats;
            IQueryable<Flat> estateQuery = await estateRepository
                .GetAllAsync();

            return new FlatListVm { Estates = estateQuery.ToList() };
        }
    }
}
