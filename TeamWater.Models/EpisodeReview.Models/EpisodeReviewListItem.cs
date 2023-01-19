using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Models.EpisodeReview.Models
{
    public class EpisodeReviewListItem
    {
        //foreign key that will trickle down
       
        public string UserName { get; set; }
           public string EpisodeName { get; set; }
    }
}