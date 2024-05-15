using ToDo.Front.Components;
using ToDo.Front.Services;
using ToDo.Front.Services.Contracts;
    
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpClient("ToDo.Client", config => { config.BaseAddress = new Uri("http://localhost:5176"); });
builder.Services.AddSingleton<IToDoService, ToDoService>();
builder.Logging.AddConsole();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();