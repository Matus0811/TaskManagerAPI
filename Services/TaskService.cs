using TaskManagerAPI.Models;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Services;

public class TaskService: ITaskService
{
    private readonly TaskManagerDbContext _context;

    public TaskService(TaskManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<TaskItem>> GetAll()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskItem?> GetById(int id)
    {
       return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TaskItem> Create(CreateTaskRequest request)
    {
        TaskItem newTask = new TaskItem(request.Title, request.Description);

        _context.Tasks.Add(newTask);
        await _context.SaveChangesAsync();
        
        return newTask;
    }

    public async Task<bool> Update(int id, UpdateTaskRequest request)
    {
        TaskItem? task = await GetById(id);
        if (task == null)
        {
            return false;
        }

        task.Title = request.Title;
        task.Description = request.Description;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        TaskItem? task = await GetById(id);
        if (task == null)
        {
            return false;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Start(int id)
    {
        TaskItem? task = await GetById(id);

        if (task == null)
        {
            return false;
        }
        
        task.Start();
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Complete(int id)
    {
        TaskItem? task = await GetById(id);

        if (task == null)
        {
            return false;
        }
        
        bool completed = task.Complete();

        if (!completed)
        {
            return false;
        }

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Cancel(int id)
    {
        TaskItem? task = await GetById(id);

        if (task == null)
        {
            return false;
        }

        bool cancelled = task.Cancel();

        if (!cancelled)
        {
            return false;
        }
        
        await _context.SaveChangesAsync();

        return true;
    }
}   