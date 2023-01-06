using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Services.TvShow;

namespace TeamWater.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowController : ControllerBase
    {
        private readonly ITvShowService _tvShowService;
        public TvShowController(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }
    }
}
