using itransition_task4_server.Data.Seed;
using itransition_task4_server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
await DbInitializer.InitDb(app);
app.Run();

