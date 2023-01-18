using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Data.Entities.Enums;

namespace TeamWater.Data.Entities
{
    public class TvShowEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ShowTitle { get; set; }

        public string ShowDescription { get; set; }

        public ShowGenre ShowGenre { get; set; }

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