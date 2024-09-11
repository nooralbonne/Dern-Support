using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportRequestController : ControllerBase
    {
        private readonly ISupportRequest _supportRequestService;

        public SupportRequestController(ISupportRequest supportRequestService)
        {
            _supportRequestService = supportRequestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportRequestDto>>> GetSupportRequests()
        {
            var supportRequests = await _supportRequestService.GetAllSupportRequests();
            return Ok(supportRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupportRequestDto>> GetSupportRequest(int id)
        {
            var supportRequest = await _supportRequestService.GetSupportRequestById(id);
            if (supportRequest == null)
            {
                return NotFound();
            }
            return Ok(supportRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportRequest(int id, SupportRequestDto supportRequestDto)
        {
            if (id != supportRequestDto.SupportRequestId)
            {
                return BadRequest();
            }

            var updatedSupportRequest = await _supportRequestService.UpdateSupportRequest(id, supportRequestDto);
            if (updatedSupportRequest == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SupportRequestDto>> PostSupportRequest(SupportRequestDto supportRequestDto)
        {
            var createdSupportRequest = await _supportRequestService.CreateSupportRequest(supportRequestDto);
            return CreatedAtAction("GetSupportRequest", new { id = createdSupportRequest.SupportRequestId }, createdSupportRequest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportRequest(int id)
        {
            await _supportRequestService.DeleteSupportRequest(id);
            return NoContent();
        }
    }
}
