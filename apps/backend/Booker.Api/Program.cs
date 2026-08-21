using Booker.Api.Data;
using Booker.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BookerDb");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Connection string 'BookerDb' is not configured. Set the ConnectionStrings__BookerDb environment variable.");
}

builder.Services.AddDbContext<BookerContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapCruiseEndpoints();
app.MapCruiseShipEndpoints();
app.MapVesselOperatorEndpoints();

app.Run();
