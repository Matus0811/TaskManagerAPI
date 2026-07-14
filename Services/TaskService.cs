using TaskManagerAPI.Models;

namespace TaskManagerAPI.Services;

public class TaskService: ITaskService
{
    private readonly List<TaskItem> _tasks;

    public TaskService()
    {
        _tasks = new List<TaskItem>()
        {
            new TaskItem(1, "First", "description"),
            new TaskItem(2, "Second", "descritpion")
        };
    }

    public List<TaskItem> GetAll()
    {
        return _tasks;
    }
}