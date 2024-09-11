using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support.Repositories.Services
{
    public class TechnicianServices : ITechnician
    {
        private readonly DernSupportDbContext _context;

        public TechnicianServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<TechnicianDto> CreateTechnician(TechnicianDto technicianDto)
        {
            var technician = new Technician
            {
                FullName = technicianDto.FullName,
                Specialization = technicianDto.Specialization,
                PhoneNumber = technicianDto.PhoneNumber,
                Email = technicianDto.Email,
                ExperienceYears = technicianDto.ExperienceYears,
                AvailabilityStatus = technicianDto.AvailabilityStatus
            };

            _context.Technicians.Add(technician);
            await _context.SaveChangesAsync();

            return new TechnicianDto
            {
                TechnicianId = technician.TechnicianId,
                FullName = technician.FullName,
                Specialization = technician.Specialization,
                PhoneNumber = technician.PhoneNumber,
                Email = technician.Email,
                ExperienceYears = technician.ExperienceYears,
                AvailabilityStatus = technician.AvailabilityStatus
            };
        }

        public async Task DeleteTechnician(int id)
        {
            var technician = await _context.Technicians.FindAsync(id);
            if (technician != null)
            {
                _context.Technicians.Remove(technician);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TechnicianDto>> GetAllTechnicians()
        {
            return await _context.Technicians
                .Select(t => new TechnicianDto
                {
                    TechnicianId = t.TechnicianId,
                    FullName = t.FullName,
                    Specialization = t.Specialization,
                    PhoneNumber = t.PhoneNumber,
                    Email = t.Email,
                    ExperienceYears = t.ExperienceYears,
                    AvailabilityStatus = t.AvailabilityStatus
                }).ToListAsync();
        }

        public async Task<TechnicianDto> GetTechnicianById(int technicianId)
        {
            var technician = await _context.Technicians.FindAsync(technicianId);
            if (technician == null) return null;

            return new TechnicianDto
            {
                TechnicianId = technician.TechnicianId,
                FullName = technician.FullName,
                Specialization = technician.Specialization,
                PhoneNumber = technician.PhoneNumber,
                Email = technician.Email,
                ExperienceYears = technician.ExperienceYears,
                AvailabilityStatus = technician.AvailabilityStatus
            };
        }

        public async Task<TechnicianDto> UpdateTechnician(int id, TechnicianDto technicianDto)
        {
            var existingTechnician = await _context.Technicians.FindAsync(id);
            if (existingTechnician != null)
            {
                existingTechnician.FullName = technicianDto.FullName;
                existingTechnician.Specialization = technicianDto.Specialization;
                existingTechnician.PhoneNumber = technicianDto.PhoneNumber;
                existingTechnician.Email = technicianDto.Email;
                existingTechnician.ExperienceYears = technicianDto.ExperienceYears;
                existingTechnician.AvailabilityStatus = technicianDto.AvailabilityStatus;

                await _context.SaveChangesAsync();

                return new TechnicianDto
                {
                    TechnicianId = existingTechnician.TechnicianId,
                    FullName = existingTechnician.FullName,
                    Specialization = existingTechnician.Specialization,
                    PhoneNumber = existingTechnician.PhoneNumber,
                    Email = existingTechnician.Email,
                    ExperienceYears = existingTechnician.ExperienceYears,
                    AvailabilityStatus = existingTechnician.AvailabilityStatus
                };
            }
            return null;
        }
    }
}
