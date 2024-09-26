public class TaskService : ITaskService {
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository) {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync() {
        return await _taskRepository.GetAllAsync();
    }

    public async Task CreateTaskAsync(TaskDto taskDto) {
        var task = TaskMapper.ToEntity(taskDto);

        await _taskRepository.AddAsync(task);
    }

    public async Task<TaskDto> GetTaskByIdAsync(string id) {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task == null) {
            return null;
        }

        return TaskMapper.ToDto(task);
    }

    public async Task<TaskDto> UpdateTaskAsync(string id, TaskDto taskDto) {
        var existingTask = await _taskRepository.GetByIdAsync(id);
        if (existingTask == null) {
            return null;
        }

        existingTask.Title = taskDto.Title;
        existingTask.Description = taskDto.Description;
        existingTask.DueDate = taskDto.DueDate;
        existingTask.Priority = taskDto.Priority;
        existingTask.Status = taskDto.Status;

        var updatedTask = await _taskRepository.UpdateAsync(existingTask);

        return TaskMapper.ToDto(updatedTask);
    }
}