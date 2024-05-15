namespace ToDo.API.Workers;

public static class Extensions
{
    public static void AddWorker(this IServiceCollection services)
    {
        services.AddHostedService<ToDoWorker>();
    }
}