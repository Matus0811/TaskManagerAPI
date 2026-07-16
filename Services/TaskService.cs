using TaskManagerAPI.Models;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Data;

namespace TaskManagerAPI.Services;

public class TaskService: ITaskService
{
    private readonly TaskManagerDbContext _context;

    public TaskService(TaskManagerDbContext context)
    {
        _context = context;
    }
    
    public List<TaskItem> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public TaskItem? GetById(int id)
    {
       return _context.Tasks.FirstOrDefault(t => t.Id == id);
    }

    public TaskItem Create(CreateTaskRequest request)
    {
        TaskItem newTask = new TaskItem(request.Title, request.Description);

        _context.Tasks.Add(newTask);
        _context.SaveChanges();
        
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
        _context.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        TaskItem? task = GetById(id);
        if (task == null)
        {
            return false;
        }

        _context.Tasks.Remove(task);
        _context.SaveChanges();

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
        _context.SaveChanges();

        return true;
    }

    public bool Complete(int id)
    {
        TaskItem? task = GetById(id);

        if (task == null)
        {
            return false;
        }
        
        bool completed = task.Complete();

        if (!completed)
        {
            return false;
        }

        _context.SaveChanges();

        return true;
    }

    public bool Cancel(int id)
    {
        TaskItem? task = GetById(id);

        if (task == null)
        {
            return false;
        }

        bool cancel = task.Cancel();

        if (!cancel)
        {
            return false;
        }
        
        _context.SaveChanges();

        return true;
    }
}   