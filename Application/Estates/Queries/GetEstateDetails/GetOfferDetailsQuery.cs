using MediatR;

namespace RealtService.Application.Estates.Queries.GetEstateDetails
{
    public class GetEstateDetailsQuery : IRequest<EstateDetailsVm>
    {
        public int Id { get; set; }
    }
}
