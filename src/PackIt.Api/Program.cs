using PackIt.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseErrorHandler();
app.UseHttpsRedirection();

app.MapGet("/get", () =>
{
});

app.Run();
