using Dern_Support.Repositories.Interfaces;

namespace Dern_Support.Model.DTO
{
    //Purpose: Represents the history of a job.


    public class JobHistoryDto
    {
        public int JobHistoryId { get; set; }
        public int JobId { get; set; }
        public string Status { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public string TechnicianNote { get; set; }
    }

}
