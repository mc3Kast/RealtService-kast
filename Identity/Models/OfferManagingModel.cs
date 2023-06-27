using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Terms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Identity.Models
{
    //Might be added more fields but for now its ok
    public class OfferManagingModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public CommercialEstate Estate { get; set; }
        [Required]
        public CommercialTerm Term { get; set; }
        public string ReturnUrl { get; set; }
    }
}
