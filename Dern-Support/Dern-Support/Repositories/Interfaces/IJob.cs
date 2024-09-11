using Dern_Support.Model.DTO;

namespace Dern_Support.Repositories.Interfaces
{
    public interface IJob
    {
        Task<JobDto> CreateJob(JobDto jobDto);
        Task<List<JobDto>> GetAllJobs();
        Task<JobDto> GetJobById(int jobId);
        Task<JobDto> UpdateJob(int id, JobDto jobDto);
        Task DeleteJob(int id);
    }
}
