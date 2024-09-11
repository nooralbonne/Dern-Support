using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support.Repositories.Services
{
    public class KnowledgeBaseServices : IKnowledgeBase
    {
        private readonly DernSupportDbContext _context;

        public KnowledgeBaseServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<KnowledgeBaseDto> CreateKnowledgeBase(KnowledgeBaseDto knowledgeBaseDto)
        {
            var knowledgeBase = new KnowledgeBase
            {
                Title = knowledgeBaseDto.Title,
                Content = knowledgeBaseDto.Content,
                Author = knowledgeBaseDto.Author
            };

            _context.KnowledgeBases.Add(knowledgeBase);
            await _context.SaveChangesAsync();

            knowledgeBaseDto.ArticleId = knowledgeBase.ArticleId;
            return knowledgeBaseDto;
        }

        public async Task DeleteKnowledgeBase(int id)
        {
            var knowledgeBase = await _context.KnowledgeBases.FindAsync(id);
            if (knowledgeBase != null)
            {
                _context.KnowledgeBases.Remove(knowledgeBase);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<KnowledgeBaseDto>> GetAllKnowledgeBases()
        {
            return await _context.KnowledgeBases
                .Select(kb => new KnowledgeBaseDto
                {
                    ArticleId = kb.ArticleId,
                    Title = kb.Title,
                    Content = kb.Content,
                    Author = kb.Author
                })
                .ToListAsync();
        }

        public async Task<KnowledgeBaseDto> GetKnowledgeBaseById(int articleId)
        {
            var knowledgeBase = await _context.KnowledgeBases.FindAsync(articleId);

            if (knowledgeBase == null)
                return null;

            return new KnowledgeBaseDto
            {
                ArticleId = knowledgeBase.ArticleId,
                Title = knowledgeBase.Title,
                Content = knowledgeBase.Content,
                Author = knowledgeBase.Author
            };
        }

        public async Task<KnowledgeBaseDto> UpdateKnowledgeBase(int id, KnowledgeBaseDto knowledgeBaseDto)
        {
            var existingArticle = await _context.KnowledgeBases.FindAsync(id);
            if (existingArticle != null)
            {
                existingArticle.Title = knowledgeBaseDto.Title;
                existingArticle.Content = knowledgeBaseDto.Content;
                existingArticle.Author = knowledgeBaseDto.Author;

                await _context.SaveChangesAsync();

                return knowledgeBaseDto;
            }
            return null;
        }
    }
}
