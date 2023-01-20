using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string ReviewTitle { get; set; }

        public int ShowRating { get; set; }
        public string ReviewText { get; set; }

        [Required]
        public DateTimeOffset DateOfReview { get; set; }

        //foreign key
        [Required]
        [ForeignKey(nameof(TvShow))]
        public int TvShowId { get; set; }
        public virtual TvShowEntity TvShow { get; set; }
    }
}