using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Models.User;
using TeamWater.Services.Token;
using TeamWater.Services.User;
using TeamWater.Models.Token;

namespace TeamWater.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ITokenService _tokenService;
        public UserController(IUserService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }
        
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registerResult = await _service.RegisterUserAsync(model);
            if (registerResult)
                return Ok("Congratulations! You have signed up to review shows!");

            return BadRequest("Shucks! Something went wrong. Go complain to the devs and try again later!");
        }

        [HttpPost("~/api/Token")]
        public async Task<IActionResult> Token([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var tokenResponse = await _tokenService.GetTokenAsync(request);
            if (tokenResponse is null)
                return BadRequest("Invalid username or password.");

            return Ok(tokenResponse);
        }

    }
}
