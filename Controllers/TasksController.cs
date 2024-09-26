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
}