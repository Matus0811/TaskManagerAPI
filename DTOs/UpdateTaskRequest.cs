using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.DTOs;

public class UpdateTaskRequest
{
    [Required]
    public required string Title {get; set;}
    public string? Description {get; set;}
}