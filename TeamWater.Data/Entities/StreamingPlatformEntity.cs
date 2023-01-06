using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Data.Entities
{
    public class StreamingPlatformEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PlatformName { get; set; }

        [Required]
        public string PlatformType { get; set; }

        //foreign key
        public int TvShowId { get; set; }
    }
}