using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Users.Commands;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand>
{
    public Task Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        //TODO: Sign out command handler
        throw new NotImplementedException();
    }
}
