using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Services.TvShowReview;

namespace TeamWater.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowReviewController : ControllerBase
    {
        private readonly ITvShowReviewService _tvShowReviewService;
        public TvShowReviewController(ITvShowReviewService tvShowReviewService)
        {
            _tvShowReviewService = tvShowReviewService;
        }
    }
}
