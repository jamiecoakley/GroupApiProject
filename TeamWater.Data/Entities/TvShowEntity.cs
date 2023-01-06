using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Data.Entities
{
    public class TvShowEntity
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string ShowTitle { get; set; }

        public string ShowDescription { get; set; }

        [Required]
        public int ShowEpisodes { get; set; }

        //foreign keys
        public int UserId { get; set; }
        public int PlatformId { get; set; }
    }
}