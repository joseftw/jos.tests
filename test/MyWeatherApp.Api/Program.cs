using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyWeatherApp.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDatabase();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

namespace MyWeatherApp.Api
{
    public partial class Program { }
}
