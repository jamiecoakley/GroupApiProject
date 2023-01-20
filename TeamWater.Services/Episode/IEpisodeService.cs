using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Models.EpisodeModels;
using TeamWater.Models;

namespace TeamWater.Services.Episode
{
    public interface IEpisodeService
    {
        Task<bool> CreateEpisodeAsync(EpisodeCreate request);
        Task<IEnumerable<EpisodeListItem>> GetAllEpisodesAsync();
        Task<EpisodeDetails> GetEpisodeByIdAsync(int EpisodeId);
        Task<bool> UpdateEpisodeAsync(EpisodeUpdate request);
        Task<bool> DeleteEpisodeAsync(int EpisodeId);
    }
}