using MediatR;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Commands.UpdateFlat
{
    public class UpdateFlatCommand : IRequest<Unit>
    {
        public User UserId { get; set; }
        public int Id { get; set; }
        public float Square { get; set; }
        public int StoreyNumber { get; set; }
        public int RoomNumber { get; set; }
        public int WCNumber { get; set; }
    }
}
