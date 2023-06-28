using MediatR;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Offers.Queries.GetOfferList
{
    public class GetOfferListQuery : IRequest<OfferListVm>
    {
        public Guid UserId { get; set; }
    }
}
