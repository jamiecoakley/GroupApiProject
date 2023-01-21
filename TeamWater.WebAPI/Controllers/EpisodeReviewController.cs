using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Models.User;
using TeamWater.Services.EpisodeReview;

namespace TeamWater.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeReviewController : ControllerBase
    {
        private readonly IEpisodeReviewService _episodeReviewService;
        public EpisodeReviewController(IEpisodeReviewService episodeReviewService)
        {
            _episodeReviewService = episodeReviewService;
        }
            [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegister model) 
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var registerResult = await _service.RegisterUserAsync(model);
            // {
            //     return Ok("User was registered.");
            // }
            return BadRequest("User could not be registered.");
    }
}
}