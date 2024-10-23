using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJob _jobService;

        public JobController(IJob jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
        {
            var jobs = await _jobService.GetAllJobs();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJob(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, JobDto jobDto)
        {
            if (id != jobDto.JobId)
            {
                return BadRequest();
            }

            var updatedJob = await _jobService.UpdateJob(id, jobDto);
            if (updatedJob == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<JobDto>> PostJob(JobDto jobDto)
        {
            var createdJob = await _jobService.CreateJob(jobDto);
            return CreatedAtAction("GetJob", new { id = createdJob.JobId }, createdJob);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            await _jobService.DeleteJob(id);
            return NoContent();
        }

        [HttpPost("Prioritize")]
        public async Task<IActionResult> PrioritizeJobs([FromBody] List<int> jobIds)
        {
            if (jobIds == null || jobIds.Count == 0)
            {
                return BadRequest("No jobs to prioritize");
            }

            await _jobService.PrioritizeJobs(jobIds);
            return Ok();
        }

    }
}
