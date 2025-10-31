using Backend.Drivers;
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


// Initialize all drivers on startup
Console.WriteLine("Initializing drivers...");
var driverTasks = new[]
{
    Task.Run(() => SeleniumDriver.InitializeYtsDriver()),
    Task.Run(() => SeleniumDriver.InitializeRarbgDriver()),
    //Task.Run(() => SeleniumDriver.InitializeTestDriver())
};
await Task.WhenAll(driverTasks);
Console.WriteLine("All drivers ready!");


// Map controllers
app.MapControllers();

// Status
app.MapGet("/api/status", () => new { message = true });

// Close drivers on shutdown
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
lifetime.ApplicationStopping.Register(() => SeleniumDriver.CloseAllDrivers());

app.Run();