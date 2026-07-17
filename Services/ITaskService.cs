using TaskManagerAPI.DTOs;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Services;
public interface ITaskService
{
    Task<List<TaskItem>> GetAll();

    Task<TaskItem?> GetById(int id);

    Task<TaskItem> Create(CreateTaskRequest request);

    Task<bool> Update(int id, UpdateTaskRequest request);

    Task<bool> Delete(int id);
    Task<bool> Start(int id);
    Task<bool> Complete(int id);
    Task<bool> Cancel(int id);
}