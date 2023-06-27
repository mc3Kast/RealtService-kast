using RealtService.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace RealtService.Identity.Controllers
{
    public class UserStatusModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public UserStatus Status { get; set; }
        public string ReturnUrl { get; set; }
    }
}
