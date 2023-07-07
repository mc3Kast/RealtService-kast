using MediatR;
using RealtService.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace RealtService.WebApi.Models;

public class SignUpCommand: IRequest<User>
{
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }
    public required string UserName { get; set; }
    public long? AgencyUniqueNumber { get; set; } 
}
