using ToDoFrontend.Models;

namespace ToDoFrontend.Interfaces;

public interface ITodoService
{
    Task AddTotoAsync(AddNewToDoDto newTodo);
    Task CompleteTodoAsync(Guid id);
    Task<IEnumerable<ToDo>?> GetListTodosAsync();
}   
