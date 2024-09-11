namespace Dern_Support.Model.DTO
{
    public class TechnicianDto
    {
        //Purpose: Represents details about a technician.
        public int TechnicianId { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ExperienceYears { get; set; }
        public string AvailabilityStatus { get; set; }
    }

}
