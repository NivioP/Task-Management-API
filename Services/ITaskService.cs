public interface ITaskService {
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task CreateTaskAsync(TaskDto taskDto);
    Task<TaskDto> GetTaskByIdAsync(string id);
    Task<TaskDto> UpdateTaskAsync(string id, TaskDto taskDto);
}