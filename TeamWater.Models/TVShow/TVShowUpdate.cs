using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Data.Entities.Enums;

namespace TeamWater.Models.TVShow
{
    public class TVShowUpdate
    {
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string ShowTitle { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(1000, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string ShowDescription { get; set; }
        [Required]
        public ShowGenre ShowGenre { get; set; }
        [Required]
        public int ShowEpisodes { get; set; } //# of episodes
        [Required]
        public int UserId { get; set; }
        public int? PlatformId { get; set; }

        public int Id { get; set; }
    }
}