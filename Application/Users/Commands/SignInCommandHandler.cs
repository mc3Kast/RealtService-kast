using MediatR;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Users.Commands;

public class SignInCommandHandler : IRequestHandler<SignInCommand, User>
{
    
    
    public Task<User> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        //TODO: Handle Sign Up Command
        throw new NotImplementedException();
    }
}
