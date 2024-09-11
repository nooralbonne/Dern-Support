using Dern_Support.Model.DTO;

namespace Dern_Support.Repositories.Interfaces
{
    public interface IKnowledgeBase
    {
        Task<KnowledgeBaseDto> CreateKnowledgeBase(KnowledgeBaseDto knowledgeBaseDto);
        Task<List<KnowledgeBaseDto>> GetAllKnowledgeBases();
        Task<KnowledgeBaseDto> GetKnowledgeBaseById(int articleId);
        Task<KnowledgeBaseDto> UpdateKnowledgeBase(int id, KnowledgeBaseDto knowledgeBaseDto);
        Task DeleteKnowledgeBase(int id);
    }
}
