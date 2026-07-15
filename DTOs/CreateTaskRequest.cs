using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.DTOs;
public class CreateTaskRequest

{
    [Required]
    public required string Title {get; set;}
    public string? Description {get; set;}

}