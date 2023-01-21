using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeamWater.Models.EpisodeModels
{
    public class EpisodeCreate
    {
        [Required]
        public int TvShowId { get; set; }
        [Required]
        public int NumberOfEpisode { get; set; }

        [Required]
        public string TitleOfEpisode { get; set; }

        [Required]
        public string SynopsisOfEpisode { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}