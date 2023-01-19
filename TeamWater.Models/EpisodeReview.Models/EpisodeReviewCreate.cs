using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Models.EpisodeReview.Models
{
    public class EpisodeReviewCreate
    {
      
        //foreign key that will trickle down
        [Required]
        public int UserId { get; set; }
        [Required]
        public int EpisodeRating { get; set; }
        [Required]
        public string EpisodeReviewText { get; set; }

        [Required]
        public DateTime DateOfReview { get; set; }

        //foreign key
        [Required]
        public int EpisodeId { get; set; }
    }
}