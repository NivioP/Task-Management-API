public static class TaskMapper {
    public static TaskDto ToDto(TaskEntity task) => new TaskDto {
        Id = task.Id,
        Title = task.Title,
        Description = task.Description,
        DueDate = task.DueDate,
        Status = task.Status,
        Priority = task.Priority,
    };
    public static TaskEntity ToEntity(TaskDto taskDto) => new TaskEntity {
        Id = Guid.NewGuid().ToString(),
        Description = taskDto.Description,
        Title = taskDto.Title,
        DueDate = taskDto.DueDate,
        Status = taskDto.Status,
        Priority = taskDto.Priority,
    };
}