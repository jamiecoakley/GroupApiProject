using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TeamWater.Data;
using TeamWater.Data.Entities;
using TeamWater.Models.EpisodeModels;
using TeamWater.Services.Episode;
using TeamWater.Models.EpisodeReview;
using System.Security.Claims;

namespace TeamWater.Services.Episode
{
    public class EpisodeService : IEpisodeService
    {
        private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;

        public EpisodeService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var episodeClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = episodeClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
                if(!validId)
                    throw new Exception("Attempted to build EpisodeService without UserId claim.");

            _dbContext = dbContext;
        }

        public async Task<bool> CreateEpisodeAsync(EpisodeCreate request)
        {
            var EpisodeEntity = new EpisodeEntity
            {
                UserId = _userId,
                NumberOfEpisode = request.NumberOfEpisode,
                TitleOfEpisode = request.TitleOfEpisode,
                SynopsisOfEpisode = request.SynopsisOfEpisode
            };

            _dbContext.Episodes.Add(EpisodeEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<EpisodeListItem>> GetAllEpisodesAsync()
        {
            var Episode = await _dbContext.Episodes
            .Select(entity => new EpisodeListItem
            {
                NumberOfEpisode = entity.NumberOfEpisode,
                TitleOfEpisode = entity.TitleOfEpisode,
                SynopsisOfEpisode = entity.SynopsisOfEpisode
            })
            .ToListAsync();

            return Episode;
        }

        public async Task<EpisodeDetails> GetEpisodeByIdAsync (int EpisodeId)
        {
            var EpisodeEntity = await _dbContext.Episodes
                .FirstOrDefaultAsync (e => e.Id == EpisodeId);

            return EpisodeEntity is null ? null : new EpisodeDetails
            {
                EpisodeId = EpisodeEntity.Id,
                NumberOfEpisode = EpisodeEntity.NumberOfEpisode,
                TitleOfEpisode = EpisodeEntity.TitleOfEpisode,
                SynopsisOfEpisode = EpisodeEntity.SynopsisOfEpisode
            };
        }

        public async Task<bool> UpdateEpisodeAsync(EpisodeUpdate request)
        {
            var EpisodeEntity = await _dbContext.Episodes.FindAsync(request.Id);
            if (EpisodeEntity?.UserId != _userId)
                return false;

            EpisodeEntity.Id = request.Id;
            EpisodeEntity.NumberOfEpisode = request.NumberOfEpisode;
            EpisodeEntity.TitleOfEpisode = request.TitleOfEpisode;
            EpisodeEntity.SynopsisOfEpisode = request.SynopsisOfEpisode;
            EpisodeEntity.UserId = request.UserId;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteEpisodeAsync(int EpisodeId)
        {
            var EpisodeEntity = await _dbContext.Episodes.FindAsync(EpisodeId);
            if (EpisodeEntity == null)
                return false;

            if (EpisodeEntity?.UserId != _userId)
                return false;

            _dbContext.Episodes.Remove(EpisodeEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}