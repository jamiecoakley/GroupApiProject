using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Models.EpisodeModels
{
    public class EpisodeDetails
    {
        public int Id { get; set; }
        public int EpisodeId { get; set; }
        public int NumberOfEpisode { get; set; }
        public string TitleOfEpisode { get; set; }
        public string SynopsisOfEpisode { get; set; }
        public DateTimeOffset EpisodeCreated { get; set; }
        public DateTimeOffset? EpisodeUpdate { get; set; }
    }
}