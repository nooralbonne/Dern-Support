namespace Dern_Support.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int JobId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // CreditCard, PayPal, Cash, BankTransfer
        public string PaymentStatus { get; set; } // Pending, Completed, Failed

        // Navigation properties
        public Job Job { get; set; }
    }
}
