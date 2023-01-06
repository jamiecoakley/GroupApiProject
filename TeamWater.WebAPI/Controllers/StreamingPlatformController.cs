using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Services.StreamingPlatform;

namespace TeamWater.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingPlatformController : ControllerBase
    {
    private readonly IStreamingPlatformService _streamingPlatformService;
        public StreamingPlatformController(IStreamingPlatformService streamingPlatformService)
        {
            _streamingPlatformService = streamingPlatformService;
        }
    }
}
