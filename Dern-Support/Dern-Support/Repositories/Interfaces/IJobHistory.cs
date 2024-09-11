using Dern_Support.Model.DTO;

namespace Dern_Support.Repositories.Interfaces
{
    public interface IJobHistory
    {
        Task<JobHistoryDto> CreateJobHistory(JobHistoryDto jobHistoryDto);
        Task<List<JobHistoryDto>> GetAllJobHistories();
        Task<JobHistoryDto> GetJobHistoryById(int jobHistoryId);
        Task<JobHistoryDto> UpdateJobHistory(int id, JobHistoryDto jobHistoryDto);
        Task DeleteJobHistory(int id);
    }
}
