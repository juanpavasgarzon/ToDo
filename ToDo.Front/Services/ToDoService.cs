using System.Text;
using System.Text.Json;
using ToDo.Front.Dtos;
using ToDo.Front.Services.Contracts;

namespace ToDo.Front.Services;

public class ToDoService : IToDoService
{
    private readonly HttpClient _client;

    public ToDoService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("ToDo.Client");
    }

    public async Task<ToDoDto> GetToDosAsync()
    {
        return await _client.GetFromJsonAsync<ToDoDto>("todo-item") ?? new ToDoDto([]);
    }

    public async Task Complete(int id, string completedNote)
    {
        var json = JsonSerializer.Serialize(new { completedNote });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PatchAsync($"todo-item/by-id/{id}", content);
    }

    public async Task Create(string title, string description)
    {
        var json = JsonSerializer.Serialize(new { title, description });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PostAsync($"todo-item", content);
    }
}