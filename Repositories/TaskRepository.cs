public class TaskRepository : ITaskRepository {
    private readonly DynamoDbContext _context;

    public TaskRepository(DynamoDbContext context) {
        _context = context;
    }


    public async Task<IEnumerable<TaskEntity>> GetAllAsync() {
        return await _context.GetAllTasksAsync();
    }

    public async Task AddAsync(TaskEntity task) {
        await _context.AddTaskAsync(task); 
    }
}