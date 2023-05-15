namespace GrindingCity.WebApi.Models;

public class UpdateTodoStatusDto
{
    public Guid Id { get; set; }
    public TodoStatus Status { get; set; }
}
