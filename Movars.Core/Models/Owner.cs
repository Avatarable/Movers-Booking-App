using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Movars.Core.Models
{
    public class Owner
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string LastName { get; set; }

        public Address? Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
