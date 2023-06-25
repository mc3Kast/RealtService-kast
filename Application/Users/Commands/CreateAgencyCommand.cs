using AutoMapper;
using MediatR;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Users.Commands;

public record class CreateAgencyCommand(
    string Name,
    string Email,
    string HashPassword,
    long? AgencyUniqueNumber,
    DateTime RegistrationDate,
    UserStatus UserStatus,
    ICollection<UserRole> UserRoles
) : IRequest<Agency>;

