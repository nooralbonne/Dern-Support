using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support.Repositories.Services
{
    public class JobServices : IJob
    {
        private readonly DernSupportDbContext _context;

        public JobServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<JobDto> CreateJob(JobDto jobDto)
        {
            var job = new Job
            {
                SupportRequestId = jobDto.SupportRequestId,
                TechnicianId = jobDto.TechnicianId,
                ScheduledDate = jobDto.ScheduledDate,
                Priority = jobDto.Priority,
                JobStatus = jobDto.JobStatus,
                EstimatedCompletionTime = jobDto.EstimatedCompletionTime,
                ActualCompletionTime = jobDto.ActualCompletionTime,
                CreatedDate = jobDto.CreatedDate
            };

            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            jobDto.JobId = job.JobId;
            return jobDto;
        }

        public async Task DeleteJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<JobDto>> GetAllJobs()
        {
            return await _context.Jobs
                .Select(job => new JobDto
                {
                    JobId = job.JobId,
                    SupportRequestId = job.SupportRequestId,
                    TechnicianId = job.TechnicianId,
                    ScheduledDate = job.ScheduledDate,
                    Priority = job.Priority,
                    JobStatus = job.JobStatus,
                    EstimatedCompletionTime = job.EstimatedCompletionTime,
                    ActualCompletionTime = job.ActualCompletionTime,
                    CreatedDate = job.CreatedDate
                })
                .ToListAsync();
        }

        public async Task<JobDto> GetJobById(int jobId)
        {
            var job = await _context.Jobs.FindAsync(jobId);

            if (job == null)
                return null;

            return new JobDto
            {
                JobId = job.JobId,
                SupportRequestId = job.SupportRequestId,
                TechnicianId = job.TechnicianId,
                ScheduledDate = job.ScheduledDate,
                Priority = job.Priority,
                JobStatus = job.JobStatus,
                EstimatedCompletionTime = job.EstimatedCompletionTime,
                ActualCompletionTime = job.ActualCompletionTime,
                CreatedDate = job.CreatedDate
            };
        }

        public async Task PrioritizeJobs(List<int> jobIds)
        {
            for (int i = 0; i < jobIds.Count; i++)
            {
                var jobId = jobIds[i];
                var job = await _context.Jobs.FindAsync(jobId); // Fetch the job by its Id

                if (job != null)
                {
                    job.Priority = (i + 1).ToString(); // Convert the int to a string
                    _context.Jobs.Update(job); // Mark the job entity as updated
                }
            }

            await _context.SaveChangesAsync(); // Persist the changes to the database
        }

        public async Task<JobDto> UpdateJob(int id, JobDto jobDto)
        {
            var existingJob = await _context.Jobs.FindAsync(id);
            if (existingJob != null)
            {
                existingJob.SupportRequestId = jobDto.SupportRequestId;
                existingJob.TechnicianId = jobDto.TechnicianId;
                existingJob.ScheduledDate = jobDto.ScheduledDate;
                existingJob.Priority = jobDto.Priority;
                existingJob.JobStatus = jobDto.JobStatus;
                existingJob.EstimatedCompletionTime = jobDto.EstimatedCompletionTime;
                existingJob.ActualCompletionTime = jobDto.ActualCompletionTime;
                existingJob.CreatedDate = jobDto.CreatedDate;

                await _context.SaveChangesAsync();

                return jobDto;
            }
            return null;
        }
    }
}
