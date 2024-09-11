using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventory _inventoryService;

        public InventoryController(IInventory inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GetInventories()
        {
            var inventories = await _inventoryService.GetAllInventories();
            return Ok(inventories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDto>> GetInventory(int id)
        {
            var inventory = await _inventoryService.GetInventoryById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, InventoryDto inventoryDto)
        {
            if (id != inventoryDto.ItemId)
            {
                return BadRequest();
            }

            var updatedInventory = await _inventoryService.UpdateInventory(id, inventoryDto);
            if (updatedInventory == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<InventoryDto>> PostInventory(InventoryDto inventoryDto)
        {
            var createdInventory = await _inventoryService.CreateInventory(inventoryDto);
            return CreatedAtAction("GetInventory", new { id = createdInventory.ItemId }, createdInventory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            await _inventoryService.DeleteInventory(id);
            return NoContent();
        }
    }
}
