using ZoneSync.Domain.Enums;
using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Services.Contracts;

public interface ITaskService
{
    TaskItem CreateTaskFromAlert(
        Alert alert,
        User createdByUser,
        int taskId,
        string name,
        string description,
        TaskPriority priority,
        DateOnly dueDate);

    TaskUser AssignTask(TaskItem task, User user);
}
