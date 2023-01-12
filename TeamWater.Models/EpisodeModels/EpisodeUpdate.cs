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
        [MinLength(1, ErrorMessage = "Title of Episode must be at least 1 characters long.")]
        [MaxLength(100, ErrorMessage = "Title of Episode cannot exceed 100 characters")]
        public string TitleOfEpisode { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Title of Episode must be at least 1 characters long.")]
        [MaxLength(500, ErrorMessage = "Title of Episode cannot exceed 500 characters")]
        public string SynopsisOfEpisode { get; set; }
    }
}