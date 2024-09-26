public interface ITaskRepository {
    Task<IEnumerable<TaskEntity>> GetAllAsync();
    Task AddAsync(TaskEntity task);
}
