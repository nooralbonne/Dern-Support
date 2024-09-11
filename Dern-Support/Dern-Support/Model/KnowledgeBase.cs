namespace Dern_Support.Model
{
    public class KnowledgeBase
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; } // Hardware, Software, Networking, Other
        public DateTime DatePublished { get; set; }
        public string Author { get; set; }

        // Navigation properties
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }
    }
}
