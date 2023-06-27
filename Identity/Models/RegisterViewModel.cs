using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RealtService.Identity.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set;}
        [Remote(action: "CheckUserType", controller: "AuthController", ErrorMessage = "No such user type!")]
        public string UserType { get; set; }
        public string ReturnUrl { get; set; }
    }
}
