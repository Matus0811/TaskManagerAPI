using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController: ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpGet]
    public ActionResult<List<TaskItem>> GetAll()
    {
        return Ok(_taskService.GetAll());
    }

    [HttpGet("{id}")] 
    public ActionResult<TaskItem> GetById(int id)
    {
        TaskItem? task = _taskService.GetById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }
    
    [HttpPost]
    public ActionResult<TaskItem> Create(CreateTaskRequest request)
    {
        TaskItem task = _taskService.Create(request);
        return Created($"/api/tasks/{task.Id}", task);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateTaskRequest request)
    {
        bool updated = _taskService.Update(id,request);

        if(!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deletet = _taskService.Delete(id);

        if(!deletet)
        {
            return NotFound();
        }
        return NoContent();
    }
}