using Dern_Support.Model;
using Dern_Support.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Repositories.Interfaces
{
    public interface ISupportRequest
    {
        Task<SupportRequestDto> CreateSupportRequest(SupportRequestDto supportRequestDto);
        Task<List<SupportRequestDto>> GetAllSupportRequests();
        Task<SupportRequestDto> GetSupportRequestById(int supportRequestId);
        Task<SupportRequestDto> UpdateSupportRequest(int id, SupportRequestDto supportRequestDto);
        Task DeleteSupportRequest(int id);
    }
}
