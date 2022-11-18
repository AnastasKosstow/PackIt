using PackIt.Api.Middlewares;
using PackIt.Application;
using PackIt.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddDomain();

var app = builder.Build();

app.UseErrorHandler();
app.UseHttpsRedirection();

app.MapGet("/get", () =>
{
});

app.Run();
