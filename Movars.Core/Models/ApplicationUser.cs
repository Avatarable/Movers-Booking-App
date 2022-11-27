using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Movars.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        // owner
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string? FirstName { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string? LastName { get; set; }


        // mover
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string? CompanyName { get; set; }

        // TODO: make required
        public string? BusinessRegNo { get; set; }

        public Address? Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public int Rating { get; set; }
    }
}
