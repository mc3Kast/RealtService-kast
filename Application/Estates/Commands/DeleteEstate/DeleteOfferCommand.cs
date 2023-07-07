using MediatR;

namespace RealtService.Application.Estates.Commands.DeleteCommand
{
    public class DeleteEstateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
