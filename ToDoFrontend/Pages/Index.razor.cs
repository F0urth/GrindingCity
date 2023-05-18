using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using ToDoFrontend.Models;

namespace ToDoFrontend.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        public IEnumerable<ToDo> tasks;
        protected override async Task OnInitializedAsync()
        {
            await GetTaskList();
        }

        protected async Task GetTaskList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:7277/api/ToDo");

            //request.Headers.Add("Access-Control-Allow-Origin", "*");
            //request.Headers.Add("Access-Control-Allow-Credentials", "true");
            //request.Headers.Add("Access-Control-Allow-Headers", "Access-Control-Allow-Origin,Content-Type");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var tasks = response.Content.ReadFromJsonAsync<IEnumerable<ToDo>>().Result;
            }
        }
    }
}
