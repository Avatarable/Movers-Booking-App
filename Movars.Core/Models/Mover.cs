using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Movars.Core.Models
{
    public class Mover : IdentityUser
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string CompanyName { get; set; }

        // TODO: make required
        public string BusinessRegNo { get; set; }

        [Required]
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
