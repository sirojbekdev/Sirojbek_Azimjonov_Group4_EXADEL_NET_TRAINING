using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task9.Data;

namespace Task9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private TaskContext _context;
        public RolesController(TaskContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _context.Roles.ToListAsync());
        }
    }
}
