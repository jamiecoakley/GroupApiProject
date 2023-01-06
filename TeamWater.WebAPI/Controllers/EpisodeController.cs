using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Services.Episode;

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
    }
}
