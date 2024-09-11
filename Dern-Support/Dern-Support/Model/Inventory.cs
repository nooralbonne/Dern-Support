namespace Dern_Support.Model
{
    public class Inventory
    {
        public int ItemId { get; set; } // Primary Key
        public string ItemName { get; set; }
        public ItemCategory Category { get; set; } // Enum: SparePart, Tool, Other
        public int QuantityInStock { get; set; }
        public decimal PricePerUnit { get; set; }
        public string SupplierName { get; set; }
        public int ReorderThreshold { get; set; }

        // Navigation property
        public ICollection<JobInventory> JobInventories { get; set; }
    }

    public enum ItemCategory
    {
        SparePart,
        Tool,
        Other
    }
}
