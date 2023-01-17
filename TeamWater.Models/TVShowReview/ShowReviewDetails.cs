using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Models.TVShowReview
{
    public class ShowReviewDetails
    {
        public int Id { get; set; }
        public string ShowTitle { get; set; }
        public string ReviewText { get; set; }
        public int ShowRating { get; set; }
        public DateTimeOffset DateOfReview { get; set; }
    }
}