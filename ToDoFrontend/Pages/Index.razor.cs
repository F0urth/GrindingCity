using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using ToDoFrontend.Interfaces;
using ToDoFrontend.Models;

namespace ToDoFrontend.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        public ITodoService TodoService { get; set; }

        public IEnumerable<ToDo>? Tasks = Array.Empty<ToDo>();
        public bool CloseAddTaskForm = true;
        public string AddTaskText = "New";

        protected override async Task OnInitializedAsync()
        {
            await GetTaskList();
        }

        protected async Task GetTaskList()
        {
            Tasks = await TodoService.GetListTodosAsync();
        }

        protected void CreateNewTaskOpenForm()
        {
            CloseAddTaskForm = false;
        }

        protected async Task CreateNewTask()
        {
            await TodoService.AddTotoAsync(new AddNewToDoDto(AddTaskText));
            await GetTaskList();

            CloseAddTaskForm = true;
        }

        protected async Task CompleteTask(Guid id)
        {
            await TodoService.CompleteTodoAsync(id);
            await GetTaskList();
            
        }
    }
}
