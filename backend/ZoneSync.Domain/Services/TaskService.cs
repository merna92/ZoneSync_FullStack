using ZoneSync.Domain.Enums;
using ZoneSync.Domain.Models;
using ZoneSync.Domain.Services.Contracts;

namespace ZoneSync.Domain.Services;

public class TaskService : ITaskService
{
    public TaskItem CreateTaskFromAlert(
        Alert alert,
        User createdByUser,
        int taskId,
        string name,
        string description,
        TaskPriority priority,
        DateOnly dueDate)
    {
        TaskItem task = new TaskItem
        {
            Id = taskId,
            ZoneId = alert.ZoneId,
            Zone = alert.Zone,
            CropPlanId = alert.CropPlanId,
            CropPlan = alert.CropPlan,
            AlertId = alert.Id,
            Alert = alert,
            CreatedByUserId = createdByUser.UserId,
            CreatedByUser = createdByUser,
            Name = name,
            Description = description,
            Status = TaskItemStatus.Pending,
            Priority = priority,
            Type = TaskType.BasedOnAlert,
            DueDate = dueDate
        };

        alert.Tasks.Add(task);
        alert.Zone?.Tasks.Add(task);
        alert.CropPlan?.Tasks.Add(task);
        createdByUser.CreatedTasks.Add(task);

        return task;
    }

    public TaskUser AssignTask(TaskItem task, User user)
    {
        TaskUser taskUser = new TaskUser
        {
            TaskId = task.Id,
            Task = task,
            UserId = user.UserId,
            User = user
        };

        task.AssignedUsers.Add(taskUser);
        user.AssignedTasks.Add(taskUser);

        return taskUser;
    }
}
