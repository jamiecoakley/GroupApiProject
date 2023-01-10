using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamWater.Models.User;
using TeamWater.Services.User;

namespace TeamWater.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
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
    }
}
