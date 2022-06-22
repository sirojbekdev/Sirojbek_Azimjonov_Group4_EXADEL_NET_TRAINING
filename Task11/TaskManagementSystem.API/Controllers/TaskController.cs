using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Application.Validators;
using TaskManagementSystem.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        private readonly TaskDtoValidator _validator;
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(ITaskService service, TaskDtoValidator validator, IUnitOfWork unitOfWork)
        {
            _service = service;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<TaskController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _service.GetTasks());
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            return Ok(await _service.GetTaskById(id));
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto task)
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
            var creator = await _unitOfWork.Users.GetById(task.CreatorId);
            User? performer = await _unitOfWork.Users.GetById(task.PerformerId);
            if (task.PerformerId == null || performer.RoleId > creator.RoleId)
            {
                var newTask = await _service.CreateTask(task);
                return CreatedAtAction("GetTaskById", new { id = newTask.Id }, newTask);
        }
            return BadRequest("Users can create tasks and assign them to other users whose role has low priority");
    }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto task)
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
            var creator = await _unitOfWork.Users.GetById(task.CreatorId);
            User? performer = await _unitOfWork.Users.GetById(task.PerformerId);
            if (task.PerformerId == null || performer.RoleId > creator.RoleId)
            {
                await _service.UpdateTask(id, task);
                return NoContent();
            }

            return BadRequest("Users can create tasks and assign them to other users whose role has low priority");
        }

        // DELETE api/<TaskController>/5
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
