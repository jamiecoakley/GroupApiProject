using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Services.Episode;
using TeamWater.Models.EpisodeModels;
using TeamWater.Models;

namespace TeamWater.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly EpisodeService _episodeService;
        public EpisodeController(EpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        // Get API/Episode
        [HttpGet]
        public async Task<IActionResult> GetAllEpisodesAsync()
        {
            var Episodes = await _episodeService.GetAllEpisodesAsync();
                return Ok(Episodes);
        }

        // Post API/Episode
        [HttpPost("Add")]
        public async Task<IActionResult> CreateEpisodeAsync([FromBody] EpisodeCreate request)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _episodeService.CreateEpisodeAsync(request))
                return Ok("Episode was created successfully.");
            
            return BadRequest("Episode could not be created...please try again!");
        }

        // Put API/Episode
        [HttpPut]
        public async Task<IActionResult> UpdateEpisodeAsync([FromBody] EpisodeUpdate request)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            return await _episodeService.UpdateEpisodeAsync(request)
            ? Ok("Episode was updated successfully!")
            : BadRequest("Episode could not be updated...please try again!");
        }

        // Delete
    }
}
