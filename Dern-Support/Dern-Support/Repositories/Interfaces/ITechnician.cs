using Dern_Support.Model.DTO;

namespace Dern_Support.Repositories.Interfaces
{
    public interface ITechnician
    {
        Task<TechnicianDto> CreateTechnician(TechnicianDto technicianDto);
        Task<List<TechnicianDto>> GetAllTechnicians();
        Task<TechnicianDto> GetTechnicianById(int technicianId);
        Task<TechnicianDto> UpdateTechnician(int id, TechnicianDto technicianDto);
        Task DeleteTechnician(int id);
    }
}
