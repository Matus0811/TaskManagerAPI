using TaskManagerAPI.DTOs;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Services;
public interface ITaskService
{
    List<TaskItem> GetAll();

    TaskItem? GetById(int id);

    TaskItem Create(CreateTaskRequest request);

    bool Update(int id, UpdateTaskRequest request);

    bool Delete(int id);
    bool Start(int id);
    bool Complete(int id);
    bool Cancel (int id);
}