using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dern_Support.Repositories.Services
{
    public class SupportRequestServices : ISupportRequest
    {
        private readonly DernSupportDbContext _context;

        public SupportRequestServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<SupportRequestDto> CreateSupportRequest(SupportRequestDto supportRequestDto)
        {
            var supportRequest = new SupportRequest
            {
                CustomerId = supportRequestDto.CustomerId,
                RequestDescription = supportRequestDto.RequestDescription,
                UrgencyLevel = supportRequestDto.UrgencyLevel,
                Status = supportRequestDto.Status,
                SubmittedDate = supportRequestDto.SubmittedDate,
                ResponseDate = supportRequestDto.ResponseDate
            };

            _context.SupportRequests.Add(supportRequest);
            await _context.SaveChangesAsync();

            supportRequestDto.SupportRequestId = supportRequest.SupportRequestId; // Ensure ID is set

            return supportRequestDto;
        }

        public async Task<List<SupportRequestDto>> GetAllSupportRequests()
        {
            var supportRequests = await _context.SupportRequests.ToListAsync();
            return supportRequests.Select(sr => new SupportRequestDto
            {
                SupportRequestId = sr.SupportRequestId,
                CustomerId = sr.CustomerId,
                RequestDescription = sr.RequestDescription,
                UrgencyLevel = sr.UrgencyLevel,
                Status = sr.Status,
                SubmittedDate = sr.SubmittedDate,
                ResponseDate = sr.ResponseDate
            }).ToList();
        }

        public async Task<SupportRequestDto> GetSupportRequestById(int supportRequestId)
        {
            var supportRequest = await _context.SupportRequests.FindAsync(supportRequestId);
            if (supportRequest == null)
            {
                return null;
            }

            return new SupportRequestDto
            {
                SupportRequestId = supportRequest.SupportRequestId,
                CustomerId = supportRequest.CustomerId,
                RequestDescription = supportRequest.RequestDescription,
                UrgencyLevel = supportRequest.UrgencyLevel,
                Status = supportRequest.Status,
                SubmittedDate = supportRequest.SubmittedDate,
                ResponseDate = supportRequest.ResponseDate
            };
        }

        public async Task<SupportRequestDto> UpdateSupportRequest(int id, SupportRequestDto supportRequestDto)
        {
            var existingRequest = await _context.SupportRequests.FindAsync(id);
            if (existingRequest == null)
            {
                return null;
            }

            existingRequest.CustomerId = supportRequestDto.CustomerId;
            existingRequest.RequestDescription = supportRequestDto.RequestDescription;
            existingRequest.UrgencyLevel = supportRequestDto.UrgencyLevel;
            existingRequest.Status = supportRequestDto.Status;
            existingRequest.SubmittedDate = supportRequestDto.SubmittedDate;
            existingRequest.ResponseDate = supportRequestDto.ResponseDate;

            await _context.SaveChangesAsync();

            return supportRequestDto;
        }

        public async Task DeleteSupportRequest(int id)
        {
            var supportRequest = await _context.SupportRequests.FindAsync(id);
            if (supportRequest != null)
            {
                _context.SupportRequests.Remove(supportRequest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
