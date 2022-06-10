using Microsoft.AspNetCore.Mvc;
using System.Text;
using Task9.Data;
using Task9.Models;
using Task9.Services;

namespace Task9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext _context;
        private readonly ITaskService _service;
        private readonly TaskVMValidator _validator;

        public TasksController(TaskContext context, TaskService service, TaskVMValidator validator)
        {
            _context = context;
            _service = service;
            _validator = validator;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _service.GetTasks());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            return Ok(await _service.GetTaskById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Models.TaskViewModel task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            var result = await _validator.ValidateAsync(task);
            if (!result.IsValid)
            {
                return BadRequest(_validator.GetErrorMessage(result));
            }
            var creator = await _context.Users.FindAsync(task.CreatorId);
            User? performer = await _context.Users.FindAsync(task.PerformerId);
            if (task.PerformerId == null || performer.RoleId > creator.RoleId)
            {
                var newTask = await _service.CreateTask(task);
                return CreatedAtAction("GetTaskById", new { id = newTask.Id }, newTask);
            }
            return BadRequest("Users can create tasks and assign them to other users whose role has low priority");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id,[FromBody] Models.TaskViewModel task)
        {
            var _task = await _service.GetTaskById(id);
            if (id < 0 || _task == null)
            {
                return NotFound();
            }
            var result = await _validator.ValidateAsync(task);
            if (!result.IsValid)
            {
                return BadRequest(_validator.GetErrorMessage(result));
            }
            var creator = await _context.Users.FindAsync(task.CreatorId);
            User? performer = await _context.Users.FindAsync(task.PerformerId);
            if (task.PerformerId == null || performer.RoleId > creator.RoleId)
            {
                await _service.UpdateTask(id, task);
                return NoContent();
            }

            return BadRequest("Users can create tasks and assign them to other users whose role has low priority");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _service.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            await _service.DeleteTask(id);
            return NoContent();
        }

    }
}
