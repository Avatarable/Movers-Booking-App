namespace Movars.Core.Models.DTOs
{
    public class ConfirmDetails
    {
        public string txn_ref { get; set; }
        public string merchant_code { get; set; }
        public decimal amount { get; set; }
    }
}
