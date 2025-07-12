using Elmasyaf.Application.DTOs;
using Elmasyaf.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elmasyaf.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is required.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userService.AddAsync(userDto);
            return Ok();
        }
    }
}
