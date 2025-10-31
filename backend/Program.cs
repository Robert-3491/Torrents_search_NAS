using Backend.Scrapers;
using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

builder.Services.AddScoped<SearchService>();
builder.Services.AddScoped<YtsScrapper>();
builder.Services.AddScoped<RarbgScraper>();
builder.Services.AddScoped<TestScraper>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowReact");

// Map controllers
app.MapControllers();

// Status
app.MapGet("/api/status", () => new { message = true });

app.Run();