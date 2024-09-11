namespace Dern_Support.Model.DTO
{
    //Purpose: Represents an inventory item.


    public class InventoryDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public ItemCategory Category { get; set; }
        public int QuantityInStock { get; set; }
        public decimal PricePerUnit { get; set; }
        public string SupplierName { get; set; }
        public int ReorderThreshold { get; set; }
    }

}
