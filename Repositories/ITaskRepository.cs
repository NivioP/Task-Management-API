using TaskManagementAPI.Models;

namespace TaskManagementAPI.Repositories {
    public interface ITaskRepository {
        Task<IEnumerable<TaskEntity>> GetAllAsync();
        Task AddAsync(TaskEntity task);
        Task<TaskEntity> GetByIdAsync(string id);
        Task<TaskEntity> UpdateAsync(TaskEntity task);
        Task DeleteAsync(string id);
    }
}
