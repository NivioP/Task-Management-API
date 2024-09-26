public class TaskService : ITaskService {
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository) {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync() {
        return await _taskRepository.GetAllAsync();
    }

    public async Task CreateTaskAsync(TaskDto taskDto) {
        var task = new TaskEntity {
            Id = Guid.NewGuid().ToString(),
            Title = taskDto.Title,
            Description = taskDto.Description,
            DueDate = taskDto.DueDate,
            Priority = taskDto.Priority,
            Status = "Pending"
        };

        await _taskRepository.AddAsync(task);
    }
}