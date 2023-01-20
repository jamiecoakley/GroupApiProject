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

        [Required]
        public string SynopsisOfEpisode { get; set; }

        // Foreign Keys
        [ForeignKey(nameof(Owner))]
        public int UserId { get; set; }
        public UserEntity Owner { get; set; }

        // // [ForeignKey(nameof(TvShowId))]
        // public int TvShowId { get; set; }

        public List<EpisodeReviewEntity> EpisodeReviewList { get; set; }
    }
}