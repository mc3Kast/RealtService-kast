using MediatR;
using Microsoft.AspNetCore.Identity;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities.Users;
using RealtService.WebApi.Models;

namespace RealtService.Application.Users.Commands;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, User>
{
    
    //TODO: Make IoC with IUnitOfWork
    private readonly UserManager<User> _userManager;

    public SignUpCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        User user;
        if (request.AgencyUniqueNumber.HasValue)
        {
            user = new Agency
            {
                AgencyUniqueNumber = request.AgencyUniqueNumber.Value,
            };
        }
        else
        {
            user = new Owner { };
        }

        user.UserName = request.UserName;
        user.Email = request.Email;

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            return user;
        }
        else 
        {
            IList<Exception> exceptions = new List<Exception>();
            foreach (IdentityError error in result.Errors)
            {
                exceptions.Add(new Exception(message: $"Identity error №{error.Code} occured: {error.Description}"));
            }
            throw new AggregateException(message: "Through create new user some errors occured", innerExceptions: exceptions);
        }
    }
}
