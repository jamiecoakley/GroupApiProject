using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Data.Entities
{
    public class EpisodeEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NumberOfEpisode { get; set; }

        [Required]
        public string TitleOfEpisode { get; set; }

        public string SynopsisOfEpisode { get; set; }

        //foreign key
        public int TvShowId { get; set; }
    }
}