using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Models.TVShowReview
{
    public class ShowReviewCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string ShowTitle { get; set; }

        [Required]
        [MaxLength(8000, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public int ShowRating { get; set; }

        [Required]
        [MaxLength(8000, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string ReviewText { get; set; }
    }
}