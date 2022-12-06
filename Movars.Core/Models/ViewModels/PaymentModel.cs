using System.ComponentModel.DataAnnotations;

namespace Movars.Core.Models.ViewModels
{
    public class PaymentModel
    {
        [Required]
        public string txn_ref { get; set; }

        [Required]
        public string merchant_code { get; set; }

        [Required]
        public string pay_item_id { get; set; }

        [Required]
        public string pay_item_name { get; set; }

        [Required]
        public decimal amount { get; set; }

        [Required]
        public string currency { get; set; }

        [Required]
        public string site_redirect_url { get; set; }

        [Required]
        public string display_mode { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
        public string? Address2 { get; set; }
    }
}
