using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Models.EpisodeReview.Models
{
    public class EpisodeReviewEdit
    {
        
        [Required]
        public int Id { get; set; }

        //foreign key that will trickle down
        [Required]
        public int UserId { get; set; }

        public int EpisodeRating { get; set; }
        public string EpisodeReviewText { get; set; }

        [Required]
        public DateTime DateOfReview { get; set; }

        //foreign key
        public int EpisodeId { get; set; }
    }
}