using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Models.TVShow;

namespace TeamWater.Services.TvShow
{
    public interface ITvShowService
    {
        Task<TVShowDetails> GetTVShowById(int showId);
        Task<bool> CreateTVShowAsync(TVShowCreate request);
        Task<bool> UpdateTVShowAsync(int showId, TVShowUpdate request);
        Task<bool> DeleteTVShowAsync(int showId);
        Task<IEnumerable<TVShowListItem>> GetAllTvShowsAsync();

        
    }
}