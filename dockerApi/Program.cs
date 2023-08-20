var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "dockerApi says hello!");

app.Run();
