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
    public async Task<ActionResult<List<TaskItem>>> GetAll()
    {
        List<TaskItem> tasks = await _taskService.GetAll();
        return Ok(tasks);
    }

    [HttpGet("{id}")] 
    public async Task<ActionResult<TaskItem>> GetById(int id)
    {
        TaskItem? task = await _taskService.GetById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }
    
    [HttpPost]
    public async Task<ActionResult<TaskItem>> Create(CreateTaskRequest request)
    {
        TaskItem task = await _taskService.Create(request);
        return Created($"/api/tasks/{task.Id}", task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTaskRequest request)
    {
        bool updated = await _taskService.Update(id,request);

        if(!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _taskService.Delete(id);

        if(!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPatch("{id}/start")]
    public async Task<IActionResult> StartTask(int id)
    {
        bool started = await _taskService.Start(id);

        if(!started)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    [HttpPatch("{id}/complete")]
    public async Task<IActionResult> CompleteTask(int id)
    {
        bool completed = await _taskService.Complete(id);

        if(!completed)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPatch("{id}/cancel")]
    public async Task<IActionResult> CancelTask(int id)
    {
        bool cancelled = await _taskService.Cancel(id);

        if(!cancelled)
        {
            return NotFound();
        }
        return NoContent();
    }
}