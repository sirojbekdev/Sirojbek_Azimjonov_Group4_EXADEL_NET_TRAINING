using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Models;

namespace TaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);
            return Ok(response);
        }
    }
}
