using MediatR;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Offers.ResidentialOffers.Commands.UpdateOffer
{
    public class UpdateResidentialOfferCommand : IRequest<Unit>
    {
        public User UserId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
