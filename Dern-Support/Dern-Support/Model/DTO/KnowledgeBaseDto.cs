namespace Dern_Support.Model.DTO
{
    //Purpose: Represents a knowledge base article.

    public class KnowledgeBaseDto
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime DatePublished { get; set; }
        public string Author { get; set; }
    }

}
