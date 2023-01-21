
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TeamWater.Data;
using TeamWater.Data.Entities;
using TeamWater.Models.EpisodeReview.Models;
using Microsoft.EntityFrameworkCore;


namespace TeamWater.Services.EpisodeReview
{
    public class EpisodeReviewService : IEpisodeReviewService
    {
        private readonly int _userId;
        private readonly ApplicationDbContext _context;

        public EpisodeReviewService(IHttpContextAccessor httpContextAcessor, ApplicationDbContext context)
        {
            var userClaims = httpContextAcessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build EpisodeReviewService without UserId claim.");

            _context = context;
        }

        public async Task<bool> CreateEpisodeReview(EpisodeReviewCreate model)
        {
            EpisodeReviewEntity entity = new EpisodeReviewEntity
            {
                UserId = model.UserId,
                EpisodeRating = model.EpisodeRating,
                EpisodeReviewText = model.EpisodeReviewText,
                DateOfReview = DateTime.Now,
                EpisodeId = model.EpisodeId,
            };
            //add rating to database 
            await _context.AddAsync(entity);
            //save to database
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEpisodeReview(int Id)
        {
            //we need to find an existing review 
            var review = await _context.EpisodeReviews.FindAsync(Id);
            //if we can't find the review
            if (review is null) return false;

            _context.EpisodeReviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EpisodeReviewListItem>> GetEpisodeReviews()
        {
            return await _context.EpisodeReviews.Include(e => e.UserEntity).Include(e => e.EpisodeEntity).Select(e => new EpisodeReviewListItem
            {
                UserName = e.UserEntity.Name,
                EpisodeName = e.EpisodeEntity.TitleOfEpisode
            }).ToListAsync();
        }

        public async Task<EpisodeReviewDetail> GetEpisodeReviews(int Id)
        {
            //we need to find an existing review 
            var review = await _context.EpisodeReviews.FindAsync(Id);
            //if we can't find the review
            if (review is null) return null;

            return new EpisodeReviewDetail
            {
                UserId = review.UserId,
                EpisodeRating = review.EpisodeRating,
                DateOfReview = review.DateOfReview,
                EpisodeId = review.EpisodeId

            };
        }

        public async Task<bool> UpdateEpisodeReview(int Id, EpisodeReviewEdit model)
        {
            //we need to find an existing review 
            var review = await _context.EpisodeReviews.FindAsync(Id);
            //if we can't find the review
            if (review is null) return false;

            review.UserId = model.UserId;
            review.EpisodeRating = model.EpisodeRating;
            review.EpisodeReviewText = model.EpisodeReviewText;
            review.DateOfReview = DateTime.Now;
            review.EpisodeId = model.EpisodeId;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}