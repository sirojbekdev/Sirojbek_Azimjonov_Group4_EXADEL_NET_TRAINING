using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Data;

namespace Task9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public TaskContext _context { get; set; }
        public UserController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }
    }
}
