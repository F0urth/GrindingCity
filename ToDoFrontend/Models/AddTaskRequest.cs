using System.Text.Json.Serialization;

namespace ToDoFrontend.Models
{
    public record AddNewToDoDto(string Title);
    public record CompleteToDoDto(Guid Id);
}
