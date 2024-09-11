namespace Dern_Support.Model
{
    public class JobInventory
    {
        public int JobInventoryId { get; set; }
        public int JobId { get; set; }
        public int ItemId { get; set; }
        public int QuantityUsed { get; set; }
        public DateTime DateUsed { get; set; }

        // Navigation properties
        public Job Job { get; set; }
        public Inventory Inventory { get; set; }
    }
}
