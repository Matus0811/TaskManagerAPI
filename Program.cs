using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddControllers();

string connectionString =
    builder.Configuration.GetConnectionString("TaskManagerDatabase") ?? 
    throw new InvalidOperationException("Connection String 'TaskManagerDatabase was not found");

builder.Services.AddDbContext<TaskManagerDbContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();

app.Run();

