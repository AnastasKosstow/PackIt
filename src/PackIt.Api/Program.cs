using PackIt.Api.Middlewares;
using PackIt.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain();

var app = builder.Build();

app.UseErrorHandler();
app.UseHttpsRedirection();

app.MapGet("/get", () =>
{
});

app.Run();
