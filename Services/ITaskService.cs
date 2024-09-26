public interface ITaskService {
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task CreateTaskAsync(TaskDto taskDto);
}