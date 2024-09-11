namespace Dern_Support.Model
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int SupportRequestId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; } // Range: 1-5
        public string Comment { get; set; } // Nullable
        public DateTime SubmittedDate { get; set; }

        // Navigation properties
        public SupportRequest SupportRequest { get; set; }
        public Customer Customer { get; set; }
    }
}
