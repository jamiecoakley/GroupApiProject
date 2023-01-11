using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Models.EpisodeReview.Models
{
    public class EpisodeReviewListItem
    {
        public int Id { get; set; }

        //foreign key that will trickle down
       
        public int UserId { get; set; }
        public string Name { get; set; }
           public int EpisodeId { get; set; }
    }
}