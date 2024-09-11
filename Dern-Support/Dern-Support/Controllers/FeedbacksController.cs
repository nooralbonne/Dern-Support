using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedback _feedbackService;

        public FeedbackController(IFeedback feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // GET: api/feedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetFeedbacks()
        {
            var feedbacks = await _feedbackService.GetAllFeedback();
            return Ok(feedbacks);
        }

        // GET: api/feedback/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDto>> GetFeedback(int id)
        {
            var feedback = await _feedbackService.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        // PUT: api/feedback/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, FeedbackDto feedbackDto)
        {
            if (id != feedbackDto.FeedbackId)
            {
                return BadRequest();
            }

            var updatedFeedback = await _feedbackService.UpdateFeedback(id, feedbackDto);
            if (updatedFeedback == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/feedback
        [HttpPost]
        public async Task<ActionResult<FeedbackDto>> PostFeedback(FeedbackDto feedbackDto)
        {
            var createdFeedback = await _feedbackService.CreateFeedback(feedbackDto);
            return CreatedAtAction("GetFeedback", new { id = createdFeedback.FeedbackId }, createdFeedback);
        }

        // DELETE: api/feedback/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            await _feedbackService.DeleteFeedback(id);
            return NoContent();
        }
    }
}
