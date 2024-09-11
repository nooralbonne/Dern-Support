namespace Dern_Support.Model.DTO
{
    //Purpose: Represents payment details related to a job.
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public int JobId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
    }

}
