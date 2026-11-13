using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Serilog;
using Serilog.Events;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IBookRepositories, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorReporisotories, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorServices>();
builder.Services.AddScoped<IGenreRepositories, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();

// Log.Logger = new LoggerConfiguration()
//     .MinimumLevel.Information()
//     .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//     .Enrich.FromLogContext()
//     .WriteTo.File("logs/Booknest.log", rollingInterval: RollingInterval.Day)
//     .CreateLogger();

// builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseMiddleware<RequestLoggingMiddleware>();
app.Run();
