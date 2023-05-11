namespace GrindingCity.WebApi.Models
{
    public class TodoEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TodoStatus Status { get; set; } = 0;
    }
}
