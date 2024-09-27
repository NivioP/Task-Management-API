using TaskManagementAPI.DTOs;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services {
    public interface ITaskService {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> CreateTaskAsync(TaskDto taskDto);
        Task<TaskDto> GetTaskByIdAsync(string id);
        Task<TaskDto> UpdateTaskAsync(string id, TaskDto taskDto);
        Task<bool> DeleteTaskAsync(string id);
    }
}