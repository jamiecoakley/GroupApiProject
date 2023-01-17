using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Data;
using TeamWater.Models.TVShowReview;
using TeamWater.Data.Entities;

namespace TeamWater.Services.TvShowReview
{
    public class TvShowReviewService : ITvShowReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly int _userId;

        // public TvShowReviewService(IHttpContextAccesssor httpContextAccesssor, ApplicationDbContext context) {
        //     var userClaims = httpContextAccesssor.HttpContext.User.Identity as ClaimsIdentity;
        //     var value = userClaims.FindFirst("Id")?.Value;

        //     var validId = int.TryParse(value, out _userId);
        //     if(!validId)
        //         throw new Exception("Attempted to build TvShowReviewService without User Id claim.");

        //         _context = context;
        // }

        public async Task<bool> CreateShowReviewAsync(ShowReviewCreate request)
        {
            var showReviewEntity = new ShowReviewEntity
            {
                // TvShow = request.ShowTitle,
                ShowRating = request.ShowRating,
                ReviewText = request.ReviewText,
                UserId = _userId
            };
            await _context.AddAsync(showReviewEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteShowReviewAsync(int showReviewId)
        {
            var showReviewEntity = await _context.ShowReviews.FindAsync(showReviewId);

            if (showReviewEntity?.UserId != _userId)
                return false;

            _context.ShowReviews.Remove(showReviewEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<IEnumerable<ShowReviewListItem>> GetAllShowReviewsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ShowReviewDetails> GetShowReviewByIdAsync(int showReviewId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNoteAsync(ShowReviewUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}