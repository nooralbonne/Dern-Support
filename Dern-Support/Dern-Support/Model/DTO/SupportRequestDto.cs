namespace Dern_Support.Model.DTO
{
    //Purpose: Represents a support request.
    public class SupportRequestDto
    {
        public int SupportRequestId { get; set; }
        public int CustomerId { get; set; }
        public string RequestDescription { get; set; }
        public string UrgencyLevel { get; set; }
        public string Status { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime? ResponseDate { get; set; }
    }

}
