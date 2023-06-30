using MediatR;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Commands.UpdateFlat
{
    public class UpdateFlatCommandHandler : IRequestHandler<UpdateFlatCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateFlatCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateFlatCommand request, CancellationToken cancellationToken)
        {
            IRepository<Flat> flatRepository = _unitOfWork.Flats;
            var entity = await flatRepository.FindAsync(request.Id);
            Console.WriteLine(entity is null);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

            entity.StoreyNumber = request.StoreyNumber;
            entity.Square = request.Square;
            entity.WCNumber = request.WCNumber;
            entity.RoomNumber = request.RoomNumber;

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
