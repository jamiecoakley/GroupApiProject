using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Models.EpisodeReview.Models
{
    public class EpisodeReviewDetail
    {
    

        //foreign key that will trickle down
     
        public int UserId { get; set; }

        public int EpisodeRating { get; set; }
        public string EpisodeReviewText { get; set; }

        public DateTime DateOfReview { get; set; }

        //foreign key
        public int EpisodeId { get; set; }
    }
}