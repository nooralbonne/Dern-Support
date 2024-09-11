using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobHistoryController : ControllerBase
    {
        private readonly IJobHistory _jobHistoryService;

        public JobHistoryController(IJobHistory jobHistoryService)
        {
            _jobHistoryService = jobHistoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobHistoryDto>>> GetJobHistories()
        {
            var jobHistories = await _jobHistoryService.GetAllJobHistories();
            return Ok(jobHistories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobHistoryDto>> GetJobHistory(int id)
        {
            var jobHistory = await _jobHistoryService.GetJobHistoryById(id);
            if (jobHistory == null)
            {
                return NotFound();
            }
            return Ok(jobHistory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobHistory(int id, JobHistoryDto jobHistoryDto)
        {
            if (id != jobHistoryDto.JobHistoryId)
            {
                return BadRequest();
            }

            var updatedJobHistory = await _jobHistoryService.UpdateJobHistory(id, jobHistoryDto);
            if (updatedJobHistory == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<JobHistoryDto>> PostJobHistory(JobHistoryDto jobHistoryDto)
        {
            var createdJobHistory = await _jobHistoryService.CreateJobHistory(jobHistoryDto);
            return CreatedAtAction("GetJobHistory", new { id = createdJobHistory.JobHistoryId }, createdJobHistory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobHistory(int id)
        {
            await _jobHistoryService.DeleteJobHistory(id);
            return NoContent();
        }
    }
}
