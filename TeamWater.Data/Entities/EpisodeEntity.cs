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

        [Required]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(TvShow))]
        public int TvShowId { get; set; }
        public virtual TvShowEntity TvShow { get; set; }

        public List<EpisodeReviewEntity> EpisodeReviewList { get; set; }
    }
}