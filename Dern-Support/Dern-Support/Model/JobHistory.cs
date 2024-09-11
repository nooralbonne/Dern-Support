using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Dern_Support.Model
{
    public class JobHistory
    {
        public int JobHistoryId { get; set; }
        public int JobId { get; set; }
        public string Status { get; set; } // Pending, In Progress, Completed, Cancelled
        public DateTime StatusChangeDate { get; set; }
        public string TechnicianNote { get; set; }

        // Navigation properties
        public Job Job { get; set; }
    }
}
