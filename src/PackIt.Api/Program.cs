using PackIt.Domain;
using PackIt.Application;
using PackIt.Infrastructure;
using PackIt.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.UseErrorHandler();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
