using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Models.EpisodeModels;
using TeamWater.Models.TVShowReview;

namespace TeamWater.Models.TVShow
{
    public class TVShowListItem
    {
        public string ShowTitle { get; set; }
        public string ShowGenre { get; set; }
        public string ShowDescription { get; set; }
        public int ShowEpisodes { get; set; }

        public List<ShowReviewListItem> Reviews { get; set; }
        public List<EpisodeListItem> Episodes { get; set; }
    }
}