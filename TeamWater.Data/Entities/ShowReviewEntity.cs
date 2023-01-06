using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Data.Entities
{
    public class ShowReviewEntity
    {
        [Key]
        public int Id { get; set; }

        //foreign key that will trickle down
        [Required]
        public int UserId { get; set; }

        public int ShowRating { get; set; }
        public string ReviewText { get; set; }

        [Required]
        public DateTime DateOfReview { get; set; }

        //foreign key
        public int TvShowId { get; set; }
    }
}