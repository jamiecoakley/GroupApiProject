using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Models.TVShowReview;

namespace TeamWater.Services.TvShowReview
{
    public interface ITvShowReviewService
    {
        Task<bool> CreateShowReviewAsync(ShowReviewCreate request);
        Task<IEnumerable<ShowReviewListItem>> GetAllShowReviewsAsync();
        Task<ShowReviewDetails> GetShowReviewByIdAsync(int showReviewId);
        Task<bool> UpdateNoteAsync(ShowReviewUpdate request);
        Task<bool> DeleteShowReviewAsync(int showReviewId);
    }
}