using RealtService.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace RealtService.Identity.Controllers
{
    public class UserRoleModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public UserRole Role { get; set; }
        public string ReturnUrl { get; set; }
    }
}
