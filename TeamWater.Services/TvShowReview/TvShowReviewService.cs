using System.Data.Common;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Data;
using TeamWater.Models.TVShowReview;
using TeamWater.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace TeamWater.Services.TvShowReview
{
    public class TvShowReviewService : ITvShowReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly int _userId;

        public TvShowReviewService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;

            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build TvShowReviewService without User Id claim.");

            _context = context;
        }

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

        public async Task<IEnumerable<ShowReviewListItem>> GetAllShowReviewsAsync()
        {
            var reviews = await _context.ShowReviews
            .Where(entity => entity.UserId == _userId)
            .Select(entity => new ShowReviewListItem
            {
                Id = entity.Id,
                ShowRating = entity.ShowRating,
                ReviewText = entity.ReviewText,
                DateOfReview = entity.DateOfReview
            }).ToListAsync();

            return reviews;
        }

        public Task<ShowReviewDetails> GetShowReviewByIdAsync(int showReviewId)
        {
            //     var showReviewEntity = await _context.ShowReviews
            //     .FirstOrDefaultAsync(e =>
            //     e.Id == showReviewId && e.UserId == _userId);

            // return showReviewEntity is null ? null : new ShowReviewDetails
            // {
            //     Id = showReviewEntity.Id,
            //     ShowTitle = showReviewEntity.TvShow,
            //     ReviewText = showReviewEntity.ReviewText,
            //     ShowRating = showReviewEntity.ShowRating,
            //     DateOfReview = showReviewEntity.DateOfReview

            throw new NotImplementedException();

            // };
        }

        public Task<bool> UpdateNoteAsync(ShowReviewUpdate request)
        {
            // var showReviewEntity = await _context.ShowReviews.FindAsync(request.Id);

            // if (showReviewEntity?.UserId != _userId)
            //     return false;

            // showReviewEntity.ReviewTitle = request.ReviewTitle;
            // showReviewEntity.ShowRating = request.ShowRating;
            // showReviewEntity.ReviewText = request.ReviewText;
            // showReviewEntity.DateOfReview = DateTimeOffset.Now;

            // var numberOfChanges = await _context.SaveChangesAsync();

            // return numberOfChanges == 1;

            throw new NotImplementedException();

        }
    }
}