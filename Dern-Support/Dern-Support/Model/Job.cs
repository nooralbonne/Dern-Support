namespace Dern_Support.Model
{
    public class Job
    {
        public int JobId { get; set; }
        public int SupportRequestId { get; set; }
        public int TechnicianId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public string JobStatus { get; set; } // Pending, In Progress, Completed, Cancelled
        public int? EstimatedCompletionTime { get; set; } // Time in hours
        public int? ActualCompletionTime { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public SupportRequest SupportRequest { get; set; }
        public Technician Technician { get; set; }
        public Payment Payment { get; set; }
        public ICollection<JobInventory> JobInventories { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }
    }
}
