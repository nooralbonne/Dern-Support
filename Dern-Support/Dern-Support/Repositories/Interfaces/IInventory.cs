using Dern_Support.Model.DTO;

namespace Dern_Support.Repositories.Interfaces
{
    public interface IInventory
    {
        Task<InventoryDto> CreateInventory(InventoryDto inventoryDto);
        Task<List<InventoryDto>> GetAllInventories();
        Task<InventoryDto> GetInventoryById(int itemId);
        Task<InventoryDto> UpdateInventory(int id, InventoryDto inventoryDto);
        Task DeleteInventory(int id);
    }
}
