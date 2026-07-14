using TaskManagerAPI.DTOs;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Services;
public interface ITaskService
{
    List<TaskItem> GetAll();

    TaskItem? GetById(int id);

    TaskItem Create(CreateTaskRequest request);
}