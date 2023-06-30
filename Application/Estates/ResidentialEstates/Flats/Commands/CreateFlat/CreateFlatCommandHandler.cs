using MediatR;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Commands.CreateFlat
{
    public class CreateFlatCommandHandler : IRequestHandler<CreateFlatCommand, Flat>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateFlatCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Flat> Handle(CreateFlatCommand request, CancellationToken cancellationToken)
        {
           var flat = new Flat
           {
                Square = request.Square,
                Offer = null,
                StoreyNumber = request.StoreyNumber,
                WCNumber = request.WCNumber,
                RoomNumber = request.RoomNumber
           };
           IRepository<Flat> repository = _unitOfWork.Flats;
           flat = repository.Insert(flat);
           await _unitOfWork.SaveChangesAsync();
           return flat;
        }
    }
}
