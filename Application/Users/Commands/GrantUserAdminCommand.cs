using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Users.Commands;

public record class GrantUserAdminCommand(int UserId): IRequest<bool>;