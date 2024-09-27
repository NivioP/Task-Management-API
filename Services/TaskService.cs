using TaskManagementAPI.DTOs;
using TaskManagementAPI.Mappers;
using TaskManagementAPI.Models;
using TaskManagementAPI.Repositories;

namespace TaskManagementAPI.Services {
    public class TaskService : ITaskService {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync() {
            var taskList = await _taskRepository.GetAllAsync();
            return taskList.Select(t => TaskMapper.ToDto(t));
        }

        public async Task<TaskDto> CreateTaskAsync(TaskDto taskDto) {
            var task = TaskMapper.ToEntity(taskDto);
            await _taskRepository.AddAsync(task);

            return TaskMapper.ToDto(task);
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

        public async Task<bool> DeleteTaskAsync(string id) {
            var existingTask = await _taskRepository.GetByIdAsync(id);

            if (existingTask == null) {
                return false;
            }

            await _taskRepository.DeleteAsync(id);

            return true;

        }
    }
}