using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Services.TvShow;
using Microsoft.AspNetCore.Authorization;

namespace TeamWater.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowController : ControllerBase
    {
        private readonly ITvShowService _tvShowService;
        public TvShowController(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }

        [HttpGet]
        [Route("/seeallshows")]
        public async Task<IActionResult> GetAllTvShows()
        {
            var shows = await _tvShowService.GetAllTvShowsAsync();
            return Ok(shows);
        }
    }


}
