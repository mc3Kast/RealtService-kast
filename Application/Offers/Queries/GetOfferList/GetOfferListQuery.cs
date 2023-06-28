using MediatR;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Offers.Queries.GetOfferList
{
    public class GetOfferListQuery : IRequest<OfferListVm>
    {
        public User UserId { get; set; }
    }
}
