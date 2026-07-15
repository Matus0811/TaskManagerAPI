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

    public void Complete()
    {
        if (Status == TaskStatus.Cancelled)
        {
            throw new InvalidOperationException("Cannot change the status of a canceled task to completed");
        }
        Status = TaskStatus.Completed;
    }

    public void Cancel()
    {
        
        if (Status == TaskStatus.Cancelled)
        {
            throw new InvalidOperationException("Cannot change the status completed of a  task to canceled");
        }
        Status = TaskStatus.Cancelled;

    }
}