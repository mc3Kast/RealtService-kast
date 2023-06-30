using MediatR;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Offers.ResidentialOffers.Commands.DeleteCommand
{
    public class DeleteOfferCommand : IRequest<Unit>
    {
        public User UserId { get; set; }
        public int Id { get; set; }
    }
}
