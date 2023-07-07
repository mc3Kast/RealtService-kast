using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.Queries.GetEstateDetails
{
    public class GetEstateDetailsQueryHandler : IRequestHandler<GetEstateDetailsQuery, EstateDetailsVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetEstateDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<EstateDetailsVm> Handle(GetEstateDetailsQuery request, CancellationToken cancellationToken)
        {
            Estate? entity = await _unitOfWork.Estates.FindAsync(request.Id);
            if (entity is null)
            {
                throw new NotFoundException(nameof(Estate), request.Id);
            }

            return _mapper.Map<EstateDetailsVm>(entity);
        }
    }
}
