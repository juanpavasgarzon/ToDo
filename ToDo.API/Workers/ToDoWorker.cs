using ToDo.Domain.ToDoItem;
using ToDo.Infrastructure.PersistenceContext.Contracts;

namespace ToDo.API.Workers;

public class ToDoWorker(IRepository repository) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var toDos = repository.GetBy<ToDoItem>(t => t.IsCompleted)
                .OrderBy(t => t.CompletedAt)
                .ToList();

            foreach (var toDo in toDos)
            {
                repository.Remove(toDo);
            }

            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }
}