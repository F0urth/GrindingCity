using System.Text.Json.Serialization;

namespace ToDoFrontend.Models
{
    public record AddNewToDoDto(string Title);
    //{
    //    [JsonPropertyName("title")]
    //    public string Title { get; set; }
    //}

}
