namespace Dern_Support.Model
{
    public class Technician
    {
        public int TechnicianId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ExperienceYears { get; set; }
        public string AvailabilityStatus { get; set; } // Available, Busy, On Leave

        // Navigation properties
        public UserAccount UserAccount { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<KnowledgeBase> KnowledgeBaseArticles { get; set; }

    }
}