using MediatR;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Users.Commands;

public class CreateAgencyCommandHandler : IRequestHandler<CreateAgencyCommand, Agency>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAgencyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Agency> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
    {
        Agency agency = new Agency()
        {
            Name = request.Name,
            Email = request.Email,
            HashPassword = request.HashPassword,
            AgencyUniqueNumber = request.AgencyUniqueNumber,
            RegistrationDate = request.RegistrationDate,
            Status = request.UserStatus,
            Roles = request.UserRoles
        };
        IRepository<User> userRepository = _unitOfWork.GetRepository<User>()!;
        agency = (Agency)userRepository.Insert(agency);
        await _unitOfWork.SaveChangesAsync();
        return agency;
    }
}
