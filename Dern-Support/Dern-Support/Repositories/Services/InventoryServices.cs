using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support.Repositories.Services
{
    public class InventoryServices : IInventory
    {
        private readonly DernSupportDbContext _context;

        public InventoryServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<InventoryDto> CreateInventory(InventoryDto inventoryDto)
        {
            var inventory = new Inventory
            {
                ItemName = inventoryDto.ItemName,
                QuantityInStock = inventoryDto.QuantityInStock,
                // Map other fields if necessary
            };

            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            inventoryDto.ItemId = inventory.ItemId;
            return inventoryDto;
        }

        public async Task DeleteInventory(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<InventoryDto>> GetAllInventories()
        {
            return await _context.Inventories
                .Select(inventory => new InventoryDto
                {
                    ItemId = inventory.ItemId,
                    ItemName = inventory.ItemName,
                    QuantityInStock = inventory.QuantityInStock,
                    // Map other fields if necessary
                })
                .ToListAsync();
        }

        public async Task<InventoryDto> GetInventoryById(int itemId)
        {
            var inventory = await _context.Inventories.FindAsync(itemId);
            if (inventory == null) return null;

            return new InventoryDto
            {
                ItemId = inventory.ItemId,
                ItemName = inventory.ItemName,
                QuantityInStock = inventory.QuantityInStock,
                // Map other fields if necessary
            };
        }

        public async Task<InventoryDto> UpdateInventory(int id, InventoryDto inventoryDto)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null) return null;

            // Update fields
            inventory.ItemName = inventoryDto.ItemName;
            inventory.QuantityInStock = inventoryDto.QuantityInStock;
            // Update other fields if necessary

            await _context.SaveChangesAsync();
            return inventoryDto;
        }
    }
}
