using TaskManagerAPI.Models;
using TaskManagerAPI.DTOs;

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

    public TaskItem? GetById(int id)
    {
       return _tasks.FirstOrDefault(t => t.Id == id );
    }

    public TaskItem Create(CreateTaskRequest request)
    {
        int id = _tasks.Count;
        id += 1;
        TaskItem newTask = new TaskItem(id, request.Title, request.Description);

        _tasks.Add(newTask);
        
        return newTask;
    }

    public bool Update(int id, UpdateTaskRequest request)
    {
        TaskItem? task = GetById(id);
        if (task == null)
        {
            return false;
        }

        task.Title = request.Title;
        task.Description = request.Description;

        return true;
    }

    public bool Delete(int id)
    {
        TaskItem? task = GetById(id);
        if (task == null)
        {
            return false;
        }

        _tasks.Remove(task);

        return true;
    }

    public bool Start(int id)
    {
        TaskItem? task = GetById(id);

        if (task == null)
        {
            return false;
        }
        
        task.Start();

        return true;
    }

    public bool Complete(int id)
    {
        TaskItem? task = GetById(id);

        if (task == null)
        {
            return false;
        }
        
        task.Complete();

        return true;
    }

    public bool Cancel(int id)
    {
        TaskItem? task = GetById(id);

        if (task == null)
        {
            return false;
        }
        
        task.Cancel();

        return true;
    }
}   