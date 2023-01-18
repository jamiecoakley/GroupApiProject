using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Models.TVShowReview;
using TeamWater.Services.TvShowReview;

namespace TeamWater.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowReviewController : ControllerBase
    {
        private readonly ITvShowReviewService _tvShowReviewService;
        public TvShowReviewController(ITvShowReviewService tvShowReviewService)
        {
            _tvShowReviewService = tvShowReviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShowReviews()
        {
            var showReviews = await _tvShowReviewService.GetAllShowReviewsAsync();
            return Ok(showReviews);
        }

        [HttpGet]
        [Route("{showReviewId}")]
        public async Task<IActionResult> GetShowReviewById([FromRoute] int showReviewId)
        {
            var detail = await _tvShowReviewService.GetShowReviewByIdAsync(showReviewId);

            return detail is not null
                ? Ok(detail)
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShowReview([FromBody] ShowReviewCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _tvShowReviewService.CreateShowReviewAsync(request))
                return Ok("Show Review created successfully.");

            return BadRequest("Show Review could not be created.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShowReviewById([FromBody] ShowReviewUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _tvShowReviewService.UpdateNoteAsync(request)
                ? Ok("Show Review updated successfully.")
                : BadRequest("Show Review could not be updated.");
        }

        [HttpDelete("{showReviewId:int}")]
        public async Task<IActionResult> DeleteShowReview([FromRoute] int showReviewId)
        {
            return await _tvShowReviewService.DeleteShowReviewAsync(showReviewId)
                ? Ok($"Note {showReviewId} was deleted successfully.")
                : BadRequest($"Note {showReviewId} could not be deleted.");
        }
    }
}
