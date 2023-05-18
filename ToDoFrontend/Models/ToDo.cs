using System.Text.Json.Serialization;

namespace ToDoFrontend.Models
{
    public class ToDo
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("status")]
        public TodoStatus Status { get; set; }
    }
}
