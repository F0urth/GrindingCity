namespace GrindingCity.WebApi.Models
{
    public class TodoDto
    {
        public string Title { get; set; }
        public TodoStatus Status { get; set; } = 0;
    }
}
