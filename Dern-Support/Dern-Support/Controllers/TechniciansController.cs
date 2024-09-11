using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private readonly ITechnician _technicianService;

        public TechnicianController(ITechnician technicianService)
        {
            _technicianService = technicianService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnicianDto>>> GetTechnicians()
        {
            var technicians = await _technicianService.GetAllTechnicians();
            return Ok(technicians);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TechnicianDto>> GetTechnician(int id)
        {
            var technician = await _technicianService.GetTechnicianById(id);
            if (technician == null)
            {
                return NotFound();
            }
            return Ok(technician);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnician(int id, TechnicianDto technicianDto)
        {
            if (id != technicianDto.TechnicianId)
            {
                return BadRequest();
            }

            var updatedTechnician = await _technicianService.UpdateTechnician(id, technicianDto);
            if (updatedTechnician == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TechnicianDto>> PostTechnician(TechnicianDto technicianDto)
        {
            var createdTechnician = await _technicianService.CreateTechnician(technicianDto);
            return CreatedAtAction("GetTechnician", new { id = createdTechnician.TechnicianId }, createdTechnician);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnician(int id)
        {
            await _technicianService.DeleteTechnician(id);
            return NoContent();
        }
    }
}
