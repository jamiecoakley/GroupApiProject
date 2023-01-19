using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Data;
using TeamWater.Models.EpisodeReview.Models;

namespace TeamWater.Services.EpisodeReview
{
    public interface IEpisodeReviewService
    {
        Task<bool> CreateEpisodeReview(EpisodeReviewCreate model);
        Task<bool> UpdateEpisodeReview(int Id, EpisodeReviewEdit model);
        Task<bool> DeleteEpisodeReview(int Id);
        Task<List<EpisodeReviewListItem>> GetEpisodeReviews();
        Task<EpisodeReviewDetail> GetEpisodeReviews(int Id);
    }
}