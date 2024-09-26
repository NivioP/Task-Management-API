using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase {
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService) {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks() {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto) {
        await _taskService.CreateTaskAsync(taskDto);
        return Ok();
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetTaskById(string id) {
        var task = await _taskService.GetTaskByIdAsync(id);

        if (task == null) {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPut("id")]
    public async Task<IActionResult> UpdateTask(string id, [FromBody] TaskDto taskDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var updatedTask = await _taskService.UpdateTaskAsync(id, taskDto);

        if (updatedTask == null) {
            return NotFound();
        }
        return Ok(updatedTask);
    }
}