using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support.Repositories.Services
{
    public class FeedbackServices : IFeedback
    {
        private readonly DernSupportDbContext _context;

        public FeedbackServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<FeedbackDto> CreateFeedback(FeedbackDto feedbackDto)
        {
            // Create a Feedback entity from DTO
            var feedback = new Feedback
            {
                SupportRequestId = feedbackDto.SupportRequestId,
                CustomerId = feedbackDto.CustomerId,
                Rating = feedbackDto.Rating,
                Comment = feedbackDto.Comment,
                SubmittedDate = feedbackDto.SubmittedDate
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            // Set the FeedbackId in DTO after saving
            feedbackDto.FeedbackId = feedback.FeedbackId;

            return feedbackDto;
        }

        public async Task DeleteFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<FeedbackDto>> GetAllFeedback()
        {
            // Query all feedbacks and project them into DTOs
            return await _context.Feedbacks
                .Select(f => new FeedbackDto
                {
                    FeedbackId = f.FeedbackId,
                    SupportRequestId = f.SupportRequestId,
                    CustomerId = f.CustomerId,
                    Rating = f.Rating,
                    Comment = f.Comment,
                    SubmittedDate = f.SubmittedDate
                })
                .ToListAsync();
        }

        public async Task<FeedbackDto> GetFeedbackById(int feedbackId)
        {
            var feedback = await _context.Feedbacks.FindAsync(feedbackId);
            if (feedback == null) return null;

            // Convert entity to DTO
            return new FeedbackDto
            {
                FeedbackId = feedback.FeedbackId,
                SupportRequestId = feedback.SupportRequestId,
                CustomerId = feedback.CustomerId,
                Rating = feedback.Rating,
                Comment = feedback.Comment,
                SubmittedDate = feedback.SubmittedDate
            };
        }

        public async Task<FeedbackDto> UpdateFeedback(int id, FeedbackDto feedbackDto)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null) return null;

            // Update fields
            feedback.SupportRequestId = feedbackDto.SupportRequestId;
            feedback.CustomerId = feedbackDto.CustomerId;
            feedback.Rating = feedbackDto.Rating;
            feedback.Comment = feedbackDto.Comment;
            feedback.SubmittedDate = feedbackDto.SubmittedDate;

            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();

            return feedbackDto;
    }
    }
}
       