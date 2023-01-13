using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TeamWater.Data;
using TeamWater.Models.TVShow;
using Microsoft.EntityFrameworkCore;

namespace TeamWater.Services.TvShow
{
    public class TvShowService : ITvShowService
    {
        private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;

        public TvShowService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var tvShowClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = tvShowClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
                if(!validId)
                    throw new Exception("Attempted to build TvShowService without UserId claim.");
            
            _dbContext = dbContext;
        }

        public Task<bool> CreateTVShowAsync(TVShowCreate request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTVShowAsync(int showId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TVShowListItem>> GetAllTvShowsAsync()
        {
            var shows = await _dbContext.TvShows
                .Include(e => e.ShowReviewList)
                .Include(e => e.EpisodeList)
                .Where(entity => entity.UserId == _userId)
                .Select(entity => new TVShowListItem
                {
                    ShowTitle = entity.ShowTitle,
                    ShowDescription = entity.ShowDescription,
                    ShowGenre = entity.ShowGenre,
                    ShowEpisodes = entity.ShowEpisodes,
                    Reviews = entity.ShowReviewList.Select(e => new ShowReviewListItem{
                            Id = e.Id,
                            Score = e.ShowRating,
                            ReviewDetails = e.ReviewText
                    }).ToList(),
                    Episodes = entity.EpisodeList.Select(e => new EpisodeListItem{
                            Id = e.Id,
                            Synopsis = e.SynopsisOfEpisode,
                            Title = e.TitleOfEpisode
                    }).ToList()
                })
                .ToListAsync();
            return shows;
        }

        public Task<TVShowDetails> GetTVShowById(int showId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTVShowAsync(int showId, TVShowUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}