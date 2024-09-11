using Dern_Support.Model.DTO;

namespace Dern_Support.Repositories.Interfaces
{
    public interface IJobInventory
    {
        Task<JobInventoryDto> CreateJobInventory(JobInventoryDto jobInventoryDto);
        Task<List<JobInventoryDto>> GetAllJobInventories();
        Task<JobInventoryDto> GetJobInventoryById(int jobInventoryId);
        Task<JobInventoryDto> UpdateJobInventory(int id, JobInventoryDto jobInventoryDto);
        Task DeleteJobInventory(int id);
    }
}
