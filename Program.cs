using itransition_task4_server.Data.Seed;
using itransition_task4_server.Endpoints;
using itransition_task4_server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "Open API");
    });
}
await DbInitializer.InitDb(app);
app.UseAppMiddlewares();    
app.MapEndpoints();
app.Run();

