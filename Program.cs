using Scalar.AspNetCore;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<ITaskService, TaskService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("api/tasks", (ITaskService taskService) =>
{
    return taskService.GetAll();
});


app.MapGet("api/tasks/{id}", (int id, ITaskService taskService) =>
{
   
    TaskItem? task = taskService.GetById(id);

    if (task == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(task);
});

app.MapPost("api/tasks", (CreateTaskRequest request, ITaskService taskService) =>
{
    if (string.IsNullOrWhiteSpace(request.Title))
    {
        return Results.BadRequest("Title is required");
    }
    TaskItem task = taskService.Create(request);
    return Results.Created($"/api/tasks/{task.Id}", task);
});

app.Run();

