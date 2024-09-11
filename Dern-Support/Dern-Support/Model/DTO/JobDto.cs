namespace Dern_Support.Model.DTO
{
    //Purpose: Represents a job associated with a support request.
    public class JobDto
    {
        public int JobId { get; set; }
        public int SupportRequestId { get; set; }
        public int TechnicianId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Priority { get; set; }
        public string JobStatus { get; set; }
        public int? EstimatedCompletionTime { get; set; }
        public int? ActualCompletionTime { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
