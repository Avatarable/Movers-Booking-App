namespace Movars.Core.Models.DTOs
{
    public class ConfirmPaymentResponse
    {
        public int Amount { get; set; }
        public string CardNumber { get; set; }
        public string MerchantReference { get; set; }
        public string PaymentReference { get; set; }
        public string RetrievalReferenceNumber { get; set; }
        public string[] SplitAccounts { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string AccountNumber { get; set; }
    }
}

