namespace Dern_Support.Model.DTO
{
    //Purpose: Represents the usage of inventory items in a job.
    public class JobInventoryDto
    {
        public int JobInventoryId { get; set; }
        public int JobId { get; set; }
        public int ItemId { get; set; }
        public int QuantityUsed { get; set; }
        public DateTime DateUsed { get; set; }
    }

}
