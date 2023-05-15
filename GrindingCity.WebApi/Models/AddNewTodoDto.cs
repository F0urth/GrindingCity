namespace GrindingCity.WebApi.Models
{
    public class AddNewTodoDto
    {
        public string Title { get; set; }
        public TodoStatus Status { get; set; } = 0;
    }
}
