using ToDo.API.Workers;
using ToDo.Infrastructure.CommandDispatcher;
using ToDo.Infrastructure.MinimalApi;
using ToDo.Infrastructure.QueryDispatcher;
using ToDo.Infrastructure.PersistenceContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddEndpoints();
builder.Services.AddRepository();
builder.Logging.AddConsole();
builder.Services.AddWorker();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();
app.UseHttpsRedirection();

app.Run();