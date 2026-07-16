using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Data;

public class TaskManagerDbContext : DbContext
{
    

    public TaskManagerDbContext( DbContextOptions<TaskManagerDbContext> options) : base(options)
    {
        
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}