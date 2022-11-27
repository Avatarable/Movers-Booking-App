using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Movars.Core.Models.ViewModels
{
    public class RegisterOwnerViewModel
    {
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string? FirstName { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string CompanyName { get; set; }
        public string BusinessRegNo { get; set; }
        public RoleType Role { get; set; }
    }

    public enum RoleType
    {
        Admin,
        Owner,
        Mover
    }
}
