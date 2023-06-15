using System.Net.Http.Json;
using ToDoFrontend.Interfaces;
using ToDoFrontend.Models;

namespace ToDoFrontend.Services;

public class TodoService : ITodoService
{
    private IHttpClientFactory _clientFactory;

    public TodoService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IEnumerable<ToDo>?> GetListTodosAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7277/api/ToDo");

        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<IEnumerable<ToDo>>();
        }

        return new List<ToDo>();
    }

    public async Task AddTotoAsync(AddNewToDoDto newTodo)
    {
        var request = new HttpRequestMessage(HttpMethod.Post,"https://localhost:7277/api/Todo");

        request.Content = JsonContent.Create(newTodo);
        var client = _clientFactory.CreateClient();

        await client.SendAsync(request);
    }

    public async Task CompleteTodoAsync(Guid id)
    {
        var request = new HttpRequestMessage(HttpMethod.Put,
                "https://localhost:7277/api/Todo/CompleteTodo");

        var requestBody = new CompleteToDoDto(id);

        request.Content = JsonContent.Create(requestBody);
        var client = _clientFactory.CreateClient();

        await client.SendAsync(request);
    }
}
