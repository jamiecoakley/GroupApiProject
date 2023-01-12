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

namespace TeamWater.Services.Episode
{
    public class EpisodeService : IEpisodeService
    {
        private readonly ApplicationDbContext _dbContext;
        public EpisodeService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateEpisodeAsync(EpisodeCreate request)
        {
            var EpisodeEntity = new EpisodeEntity
            {
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

        public async Task<bool> UpdateEpisodeAsync(EpisodeUpdate request)
        {
            var EpisodeEntity = await _dbContext.Episodes.FindAsync(request.Id);

            EpisodeEntity.NumberOfEpisode = request.NumberOfEpisode;
            EpisodeEntity.TitleOfEpisode = request.TitleOfEpisode;
            EpisodeEntity.SynopsisOfEpisode = request.SynopsisOfEpisode;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        // public async Task<bool> DeleteEpisodeAsync (int EpisodeId)
        // {

        // }
    }
}