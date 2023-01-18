using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Data.Entities.Enums;


namespace TeamWater.Models.TVShow
{
    public class TVShowCreate
    {
        [Required]
        public string ShowTitle { get; set; }
        [Required]
        public string ShowDescription { get; set; }
        [Required]
        public ShowGenre ShowGenre { get; set; }
        [Required]
        public int ShowEpisodes { get; set; } //# of episodes
        [Required]
        public int UserId { get; set; }
        public int? PlatformId { get; set; }

    }
}