using MediatR;
using RealtService.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace RealtService.Application.Users.Commands;

public class SignInCommand: IRequest<User>
{
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }

    public bool RememberMe { get; set; }

    [DataType(DataType.Url)]
    public string? ReturnUrl { get; set; }
}
