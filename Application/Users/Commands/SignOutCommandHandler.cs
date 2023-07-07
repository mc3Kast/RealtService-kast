using MediatR;
using RealtService.Application.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Users.Commands;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SignOutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.SignInManager.SignOutAsync();
    }
}
