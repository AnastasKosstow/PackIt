using PackIt.Api.Middlewares;
using PackIt.Application;
using PackIt.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication();

builder.Services.AddControllers();

var app = builder.Build();

app.UseErrorHandler();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
