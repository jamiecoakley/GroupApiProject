using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TeamWater.Data;
using TeamWater.Models.TVShow;
using Microsoft.EntityFrameworkCore;
using TeamWater.Data.Entities;
using TeamWater.Models.TVShowReview;
using TeamWater.Models.EpisodeModels;

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

        public async Task<bool> CreateTVShowAsync(TVShowCreate request)
        {
            var showEntity = new TvShowEntity
            {
                //UserId = _userId,
                ShowTitle = request.ShowTitle,
                ShowDescription = request.ShowDescription,
                ShowGenre = request.ShowGenre,
                ShowEpisodes = request.ShowEpisodes
            };

            _dbContext.TvShows.Add(showEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteTVShowAsync(int showId)
        {
            var tvShowEntity = await _dbContext.TvShows.FindAsync(showId);
            if (tvShowEntity == null)
                return false; 

            // if (tvShowEntity?.UserId != _userId)
            //     return false;

            _dbContext.TvShows.Remove(tvShowEntity);
                await _dbContext.SaveChangesAsync();
                return true;           
        }

        public async Task<IEnumerable<TVShowListItem>> GetAllTvShowsAsync()
        {
            var shows = await _dbContext.TvShows
                .Include(e => e.ShowReviewList)
                .Include(e => e.EpisodeList)
                //.Where(entity => entity.UserId == _userId)
                .Select(entity => new TVShowListItem
                {
                    ShowTitle = entity.ShowTitle,
                    ShowDescription = entity.ShowDescription,
                    ShowEpisodes = entity.ShowEpisodes,
                    Reviews = entity.ShowReviewList.Select(e => new ShowReviewListItem{
                            Id = e.Id,
                            ShowRating = e.ShowRating,
                            ReviewText = e.ReviewText,
                            //UserId = e.UserId
                    }).ToList(),
                    Episodes = entity.EpisodeList.Select(e => new EpisodeListItem{
                            // Id = e.Id,
                            NumberOfEpisode = e.NumberOfEpisode,
                            TitleOfEpisode = e.TitleOfEpisode,
                            SynopsisOfEpisode = e.SynopsisOfEpisode
                    }).ToList()
                })
                .ToListAsync();
            return shows;
        }

        public async Task<TVShowDetails> GetTVShowByIdAsync(int showId)
        {
            var tvShowEntity = await _dbContext.TvShows
                .FirstOrDefaultAsync (e => e.Id == showId);

            return tvShowEntity is null ? null : new TVShowDetails
            {
                ShowId = tvShowEntity.Id,
                ShowTitle = tvShowEntity.ShowTitle,
                ShowDescription = tvShowEntity.ShowDescription
            };
        }

        public async Task<TVShowDetails> GetTVShowByTitleAsync(string title)
        {
            var titleEntity = await _dbContext.TvShows
                .FirstOrDefaultAsync (e => e.ShowTitle == title);

            return titleEntity is null ? null : new TVShowDetails
            {
                ShowTitle = titleEntity.ShowTitle,
                ShowDescription = titleEntity.ShowDescription
            };
        }

        public async Task<bool> UpdateTVShowAsync(TVShowUpdate request)
        {
            var tvShowEntity = await _dbContext.TvShows.FindAsync(request.Id);
            // if (tvShowEntity?.UserId != _userId)
            //     return false;
            
            tvShowEntity.Id = request.Id;
            tvShowEntity.ShowTitle = request.ShowTitle;
            tvShowEntity.ShowDescription = request.ShowDescription;
            tvShowEntity.ShowGenre = request.ShowGenre;
            tvShowEntity.ShowEpisodes = request.ShowEpisodes;
            //tvShowEntity.UserId = request.UserId;
            //tvShowEntity.PlatformId = request.PlatformId;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
    }
}


//     public class TvShowService : ITvShowService
//     {
//         private readonly int _userId;
//         private readonly ApplicationDbContext _dbContext;

//         public TvShowService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
//         {
//             var tvShowClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
//             var value = tvShowClaims.FindFirst("Id")?.Value;
//             var validId = int.TryParse(value, out _userId);
//                 if(!validId)
//                     throw new Exception("Attempted to build TvShowService without UserId claim.");
            
//             _dbContext = dbContext;
//         }

//         public Task<bool> CreateTVShowAsync(TVShowCreate request)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<bool> DeleteTVShowAsync(int showId)
//         {
//             throw new NotImplementedException();
//         }

//         public async Task<IEnumerable<TVShowListItem>> GetAllTvShowsAsync()
//         {
//             var shows = await _dbContext.TvShows
//                 .Include(e => e.ShowReviewList)
//                 .Include(e => e.EpisodeList)
//                 .Where(entity => entity.UserId == _userId)
//                 .Select(entity => new TVShowListItem
//                 {
//                     ShowTitle = entity.ShowTitle,
//                     ShowDescription = entity.ShowDescription,
//                     ShowGenre = entity.ShowGenre,
//                     ShowEpisodes = entity.ShowEpisodes,
//                     Reviews = entity.ShowReviewList.Select(e => new ShowReviewListItem{
//                             Id = e.Id,
//                             Score = e.ShowRating,
//                             ReviewDetails = e.ReviewText
//                     }).ToList(),
//                     Episodes = entity.EpisodeList.Select(e => new EpisodeListItem{
//                             Id = e.Id,
//                             Synopsis = e.SynopsisOfEpisode,
//                             Title = e.TitleOfEpisode
//                     }).ToList()
//                 })
//                 .ToListAsync();
//             return shows;
//         }

//         public Task<TVShowDetails> GetTVShowById(int showId)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<bool> UpdateTVShowAsync(int showId, TVShowUpdate request)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }