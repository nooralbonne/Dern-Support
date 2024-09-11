using Dern_Support.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dern_Support.Repositories.Interfaces
{
    public interface IFeedback
    {
        Task<FeedbackDto> CreateFeedback(FeedbackDto feedbackDto);
        Task<List<FeedbackDto>> GetAllFeedback();
        Task<FeedbackDto> GetFeedbackById(int feedbackId);
        Task<FeedbackDto> UpdateFeedback(int id, FeedbackDto feedbackDto);
        Task DeleteFeedback(int id);
    }
}
