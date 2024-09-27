using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Repositories {
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

        public async Task<TaskEntity> GetByIdAsync(string id) {
            return await _context.GetTaskByIdAsync(id);
        }

        public async Task<TaskEntity> UpdateAsync(TaskEntity task) {
            await _context.UpdateTaskAsync(task);
            return task;
        }

        public async Task DeleteAsync(string id) {
            await _context.DeleteTaskAsync(id);
        }
    }
}