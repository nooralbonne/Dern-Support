using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeBaseController : ControllerBase
    {
        private readonly IKnowledgeBase _knowledgeBaseService;

        public KnowledgeBaseController(IKnowledgeBase knowledgeBaseService)
        {
            _knowledgeBaseService = knowledgeBaseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnowledgeBaseDto>>> GetKnowledgeBases()
        {
            var knowledgeBases = await _knowledgeBaseService.GetAllKnowledgeBases();
            return Ok(knowledgeBases);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KnowledgeBaseDto>> GetKnowledgeBase(int id)
        {
            var knowledgeBase = await _knowledgeBaseService.GetKnowledgeBaseById(id);
            if (knowledgeBase == null)
            {
                return NotFound();
            }
            return Ok(knowledgeBase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnowledgeBase(int id, KnowledgeBaseDto knowledgeBaseDto)
        {
            if (id != knowledgeBaseDto.ArticleId)
            {
                return BadRequest();
            }

            var updatedKnowledgeBase = await _knowledgeBaseService.UpdateKnowledgeBase(id, knowledgeBaseDto);
            if (updatedKnowledgeBase == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<KnowledgeBaseDto>> PostKnowledgeBase(KnowledgeBaseDto knowledgeBaseDto)
        {
            var createdKnowledgeBase = await _knowledgeBaseService.CreateKnowledgeBase(knowledgeBaseDto);
            return CreatedAtAction("GetKnowledgeBase", new { id = createdKnowledgeBase.ArticleId }, createdKnowledgeBase);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKnowledgeBase(int id)
        {
            await _knowledgeBaseService.DeleteKnowledgeBase(id);
            return NoContent();
        }
    }
}
