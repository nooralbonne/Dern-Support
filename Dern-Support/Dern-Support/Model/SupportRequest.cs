namespace Dern_Support.Model
{
    public class SupportRequest
    {
        public int SupportRequestId { get; set; }
        public int CustomerId { get; set; }
        public string RequestDescription { get; set; }
        public string UrgencyLevel { get; set; } // Low, Medium, High
        public string Status { get; set; } // Submitted, Approved, Declined
        public DateTime SubmittedDate { get; set; }
        public DateTime? ResponseDate { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
