using JokesMCP;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer()
    .WithToolsFromAssembly()
    .WithHttpTransport();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<JokesService>();

var app = builder.Build();

app.MapMcp();

app.Run();