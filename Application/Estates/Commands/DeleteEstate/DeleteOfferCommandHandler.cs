using MediatR;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Application.Estates.Commands.DeleteCommand;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.Commands.DeleteCommand
{
    public class DeleteEstateCommandHandler : IRequestHandler<DeleteEstateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteEstateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteEstateCommand request, CancellationToken cancellationToken)
        {
            IRepository<Estate> estateRepository = _unitOfWork.Estates;
            var entity = await estateRepository.FindAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Estate), request.Id);
            }

            estateRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }

    }
}
