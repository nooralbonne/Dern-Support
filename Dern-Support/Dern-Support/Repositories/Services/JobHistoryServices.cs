using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support.Repositories.Services
{
    public class JobHistoryServices : IJobHistory
    {
        private readonly DernSupportDbContext _context;

        public JobHistoryServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<JobHistoryDto> CreateJobHistory(JobHistoryDto jobHistoryDto)
        {
            var jobHistory = new JobHistory
            {
                JobId = jobHistoryDto.JobId,
                Status = jobHistoryDto.Status,
                StatusChangeDate = jobHistoryDto.StatusChangeDate,
                TechnicianNote = jobHistoryDto.TechnicianNote
            };

            _context.JobHistories.Add(jobHistory);
            await _context.SaveChangesAsync();

            jobHistoryDto.JobHistoryId = jobHistory.JobHistoryId;
            return jobHistoryDto;
        }

        public async Task DeleteJobHistory(int id)
        {
            var jobHistory = await _context.JobHistories.FindAsync(id);
            if (jobHistory != null)
            {
                _context.JobHistories.Remove(jobHistory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<JobHistoryDto>> GetAllJobHistories()
        {
            return await _context.JobHistories
                .Select(jh => new JobHistoryDto
                {
                    JobHistoryId = jh.JobHistoryId,
                    JobId = jh.JobId,
                    Status = jh.Status,
                    StatusChangeDate = jh.StatusChangeDate,
                    TechnicianNote = jh.TechnicianNote
                })
                .ToListAsync();
        }

        public async Task<JobHistoryDto> GetJobHistoryById(int jobHistoryId)
        {
            var jobHistory = await _context.JobHistories.FindAsync(jobHistoryId);

            if (jobHistory == null)
                return null;

            return new JobHistoryDto
            {
                JobHistoryId = jobHistory.JobHistoryId,
                JobId = jobHistory.JobId,
                Status = jobHistory.Status,
                StatusChangeDate = jobHistory.StatusChangeDate,
                TechnicianNote = jobHistory.TechnicianNote
            };
        }

        public async Task<JobHistoryDto> UpdateJobHistory(int id, JobHistoryDto jobHistoryDto)
        {
            var existingJobHistory = await _context.JobHistories.FindAsync(id);
            if (existingJobHistory != null)
            {
                existingJobHistory.JobId = jobHistoryDto.JobId;
                existingJobHistory.Status = jobHistoryDto.Status;
                existingJobHistory.StatusChangeDate = jobHistoryDto.StatusChangeDate;
                existingJobHistory.TechnicianNote = jobHistoryDto.TechnicianNote;

                await _context.SaveChangesAsync();

                return jobHistoryDto;
            }
            return null;
        }
    }
}
