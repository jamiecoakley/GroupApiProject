using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Services.EpisodeReview;

namespace TeamWater.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeReviewController : ControllerBase
    {
        private readonly EpisodeReviewService _episodeReviewService;
        public EpisodeReviewController(EpisodeReviewService episodeReviewService)
        {
            _episodeReviewService = episodeReviewService;
        }
    }
}
