using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Data.Entities
{
    public class TvShowEntity
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string ShowTitle { get; set; }

        public string ShowDescription { get; set; }

        public string ShowGenre { get; set; }

        [Required]
        public int ShowEpisodes { get; set; } //# of episodes

        //foreign keys
        [ForeignKey(nameof (Owner))]
        public int UserId { get; set; }
        public UserEntity Owner { get; set; }

        [ForeignKey(nameof(WhereToStream))]
        public int? PlatformId { get; set; }
        public StreamingPlatformEntity? WhereToStream { get; set;} 

        public List<ShowReviewEntity> ShowReviewList { get; set; }
        public List<EpisodeEntity> EpisodeList { get; set; }
    }
}