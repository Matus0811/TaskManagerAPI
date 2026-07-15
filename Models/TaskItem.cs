namespace TaskManagerAPI.Models;

public class TaskItem
{
    public int Id {get; set;}
    public string Title {get;set;}
    public string? Description {get; set;}
    public TaskStatus Status {get; private set;}

    public TaskItem (int id, string title, string? description)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = TaskStatus.ToDo;
    }

    public void Start()
    {
        Status = TaskStatus.InProgress;
    }

    public bool Complete()
    {
        if (Status == TaskStatus.Cancelled)
        {
            return false;
        }
        Status = TaskStatus.Completed;
        return true;
    }

    public bool Cancel()
    {
        
        if (Status == TaskStatus.Completed)
        {
            return false;
        }
        Status = TaskStatus.Cancelled;
        return true;

    }
}