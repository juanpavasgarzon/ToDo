using ToDo.Front.Dtos;

namespace ToDo.Front.Services.Contracts;

public interface IToDoService
{
    public Task<ToDoDto> GetToDosAsync();
    public Task Complete(int Id, string CompletedNote);
    public Task Create(string Title, string Description);
}