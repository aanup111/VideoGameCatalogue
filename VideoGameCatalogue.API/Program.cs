using Microsoft.EntityFrameworkCore;
using VideoGameCatalogue.Core.Interfaces;
using VideoGameCatalogue.Data;
using VideoGameCatalogue.Services;

var builder = WebApplication.CreateBuilder(args);

// Register the database context with SQL Server connection string
builder.Services.AddDbContext<VideoGameCatalogueContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repository and service for dependency injection
builder.Services.AddScoped<IVideoGameRepository, VideoGameRepository>();
builder.Services.AddScoped<IVideoGameService, VideoGameService>();

// Add controllers and OpenAPI documentation services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Only enable OpenAPI documentation in development environment for security reasons
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Allow Angular frontend to call the API
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();