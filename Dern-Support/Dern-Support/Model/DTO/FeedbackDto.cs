namespace Dern_Support.Model.DTO
{
    //Purpose: Represents feedback provided by customers.


    public class FeedbackDto
    {
        public int FeedbackId { get; set; }
        public int SupportRequestId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime SubmittedDate { get; set; }
    }

}
