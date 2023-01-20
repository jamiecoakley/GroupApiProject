using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Models.TVShowReview
{
    public class ShowReviewListItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ReviewTitle { get; set; }
        public int ShowRating { get; set; }
        public string ReviewText { get; set; }
        public DateTimeOffset DateOfReview { get; set; }
    }
}