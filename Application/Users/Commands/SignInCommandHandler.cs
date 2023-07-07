using MediatR;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Users.Commands;

public class SignInCommandHandler : IRequestHandler<SignInCommand, User>
{
    private readonly IUnitOfWork _unitOfWork;

    public SignInCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<User> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        User? requestedUser = await _unitOfWork.UserManager.FindByEmailAsync(request.Email);
        if (requestedUser is null)
        {
            throw new NotFoundException(objectName: "User", keyName: $"email {request.Email}");
        }

        await _unitOfWork.SignInManager.SignInAsync(user: requestedUser, isPersistent: request.RememberMe);
        return requestedUser;
    }
}
