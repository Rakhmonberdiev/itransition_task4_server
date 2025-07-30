using itransition_task4_server.Data.Seed;
using itransition_task4_server.Endpoints;
using itransition_task4_server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy
          .WithOrigins("http://localhost:4200") 
          .AllowAnyHeader()                      
          .AllowAnyMethod()                       
          .AllowCredentials();                    
    });
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "Open API");
    });
    app.UseCors("AllowAngularDev");
}
app.UseCors();
await DbInitializer.InitDb(app);
app.UseAppMiddlewares();    
app.MapEndpoints();
app.Run();

