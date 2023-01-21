using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeamWater.Models.EpisodeModels
{
    public class EpisodeUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int NumberOfEpisode { get; set; }

        [Required]
        public string TitleOfEpisode { get; set; }

        [Required]
        public string SynopsisOfEpisode { get; set; }

        public int UserId { get; set; }
    }
}