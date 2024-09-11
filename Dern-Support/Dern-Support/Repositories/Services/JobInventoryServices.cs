using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support.Repositories.Services
{
    public class JobInventoryServices : IJobInventory
    {
        private readonly DernSupportDbContext _context;

        public JobInventoryServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<JobInventoryDto> CreateJobInventory(JobInventoryDto jobInventoryDto)
        {
            var jobInventory = new JobInventory
            {
                JobId = jobInventoryDto.JobId,
                ItemId = jobInventoryDto.ItemId,
                QuantityUsed = jobInventoryDto.QuantityUsed,
                DateUsed = jobInventoryDto.DateUsed
            };

            _context.JobInventories.Add(jobInventory);
            await _context.SaveChangesAsync();

            jobInventoryDto.JobInventoryId = jobInventory.JobInventoryId;
            return jobInventoryDto;
        }

        public async Task DeleteJobInventory(int id)
        {
            var jobInventory = await _context.JobInventories.FindAsync(id);
            if (jobInventory != null)
            {
                _context.JobInventories.Remove(jobInventory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<JobInventoryDto>> GetAllJobInventories()
        {
            return await _context.JobInventories
                .Select(ji => new JobInventoryDto
                {
                    JobInventoryId = ji.JobInventoryId,
                    JobId = ji.JobId,
                    ItemId = ji.ItemId,
                    QuantityUsed = ji.QuantityUsed,
                    DateUsed = ji.DateUsed
                })
                .ToListAsync();
        }

        public async Task<JobInventoryDto> GetJobInventoryById(int jobInventoryId)
        {
            var jobInventory = await _context.JobInventories.FindAsync(jobInventoryId);

            if (jobInventory == null)
                return null;

            return new JobInventoryDto
            {
                JobInventoryId = jobInventory.JobInventoryId,
                JobId = jobInventory.JobId,
                ItemId = jobInventory.ItemId,
                QuantityUsed = jobInventory.QuantityUsed,
                DateUsed = jobInventory.DateUsed
            };
        }

        public async Task<JobInventoryDto> UpdateJobInventory(int id, JobInventoryDto jobInventoryDto)
        {
            var existingJobInventory = await _context.JobInventories.FindAsync(id);
            if (existingJobInventory != null)
            {
                existingJobInventory.JobId = jobInventoryDto.JobId;
                existingJobInventory.ItemId = jobInventoryDto.ItemId;
                existingJobInventory.QuantityUsed = jobInventoryDto.QuantityUsed;
                existingJobInventory.DateUsed = jobInventoryDto.DateUsed;

                await _context.SaveChangesAsync();

                return jobInventoryDto;
            }
            return null;
        }
    }
}
