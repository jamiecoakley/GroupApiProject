using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Services.TvShow;
using Microsoft.AspNetCore.Authorization;
using TeamWater.Models.TVShow;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("/seeallshows")]
        public async Task<IActionResult> GetAllTvShows()
        {
            var shows = await _tvShowService.GetAllTvShowsAsync();
            return Ok(shows);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/createshow")]
        public async Task<IActionResult> CreateTVShow([FromBody] TVShowCreate request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(await _tvShowService.CreateTVShowAsync(request))
                return Ok("TV Show entry created successfully!");

            return BadRequest("TV Show entry failed to enter...");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("/getshowbyid/{showId:int}")]
        public async Task<IActionResult> GetTVShowById([FromRoute] int showId)
        {
            var detail = await _tvShowService.GetTVShowByIdAsync(showId);
            return detail is not null ? Ok(detail) : NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("/getshowbytitle")]
        public async Task<IActionResult> GetTVShowByTitle([FromQuery] string showTitle)
        {
            var detail = await _tvShowService.GetTVShowByTitleAsync(showTitle);
            return detail is not null ? Ok(detail) : NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/updateshow")]
        public async Task<IActionResult> UpdateTvShowById([FromBody] TVShowUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _tvShowService.UpdateTVShowAsync(request)
                ? Ok("TV Show Entry Successfully Updated!")
                : BadRequest("TV Show Wasn't Updated.");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{showId:int}")]
        public async Task<IActionResult>DeleteTVShow(int showId)
        {
            return await _tvShowService.DeleteTVShowAsync(showId)
                ? Ok($"TV Show associated with ID #{showId} was successfully deleted.")
                : BadRequest($"TV Show associated with ID #{showId} remains in the database.");
        }
    }
}
