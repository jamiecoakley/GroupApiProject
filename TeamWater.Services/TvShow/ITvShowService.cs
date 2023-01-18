using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Models.TVShow;

namespace TeamWater.Services.TvShow
{
    public interface ITvShowService
    {
        Task<TVShowDetails> GetTVShowByIdAsync(int showId);

        //Task<TVShowDetails>GetTVShowByTitleAsync(string title);
        Task<bool> CreateTVShowAsync(TVShowCreate request);
        Task<bool> UpdateTVShowAsync(TVShowUpdate request);
        Task<bool> DeleteTVShowAsync(int showId);
        Task<IEnumerable<TVShowListItem>> GetAllTvShowsAsync();

        
    }
}