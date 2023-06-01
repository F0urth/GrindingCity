using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using ToDoFrontend.Models;

namespace ToDoFrontend.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        public IEnumerable<ToDo> Tasks = Array.Empty<ToDo>();
        public bool CloseAddTaskForm = true;
        public string AddTaskText = "New";

        protected override async Task OnInitializedAsync()
        {
            await GetTaskList();
        }

        protected async Task GetTaskList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:7277/api/ToDo");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Tasks = response.Content.ReadFromJsonAsync<IEnumerable<ToDo>>().Result;
            }
        }

        protected async Task CreateNewTaskOpenForm()
        {
            CloseAddTaskForm = false;
        }

        protected async Task CreateNewTask()
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://localhost:7277/api/Todo");

            var requestBody = new AddNewToDoDto(AddTaskText);

            request.Content = JsonContent.Create(requestBody);
            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                await GetTaskList();
                CloseAddTaskForm = true;
            }
        }
    }
}
