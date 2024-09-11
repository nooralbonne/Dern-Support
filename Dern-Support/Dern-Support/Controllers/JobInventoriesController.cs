using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobInventoryController : ControllerBase
    {
        private readonly IJobInventory _jobInventoryService;

        public JobInventoryController(IJobInventory jobInventoryService)
        {
            _jobInventoryService = jobInventoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobInventoryDto>>> GetJobInventories()
        {
            var jobInventories = await _jobInventoryService.GetAllJobInventories();
            return Ok(jobInventories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobInventoryDto>> GetJobInventory(int id)
        {
            var jobInventory = await _jobInventoryService.GetJobInventoryById(id);
            if (jobInventory == null)
            {
                return NotFound();
            }
            return Ok(jobInventory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobInventory(int id, JobInventoryDto jobInventoryDto)
        {
            if (id != jobInventoryDto.JobInventoryId)
            {
                return BadRequest();
            }

            var updatedJobInventory = await _jobInventoryService.UpdateJobInventory(id, jobInventoryDto);
            if (updatedJobInventory == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<JobInventoryDto>> PostJobInventory(JobInventoryDto jobInventoryDto)
        {
            var createdJobInventory = await _jobInventoryService.CreateJobInventory(jobInventoryDto);
            return CreatedAtAction("GetJobInventory", new { id = createdJobInventory.JobInventoryId }, createdJobInventory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobInventory(int id)
        {
            await _jobInventoryService.DeleteJobInventory(id);
            return NoContent();
        }
    }
}
