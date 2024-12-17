using Microsoft.EntityFrameworkCore;
using Tapanyagok.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// DBContext hozz�ad�sa
builder.Services.AddDbContext<TapanyagContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("TapanyagDB"),
        ServerVersion.Parse("10.4.28-mariadb"))
    );
// CORS enged�lyez�se
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => 
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
// CORS szab�ly alkalmaz�sa
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
