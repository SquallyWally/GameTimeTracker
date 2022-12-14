using HowLongToBeat.Api.Context;
using HowLongToBeat.Api.Repositories;
using HowLongToBeat.Api.TrackerService;
using HowLongToBeat.Api.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://localhost:5002/");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<GameContext>(opt => opt.UseSqlServer("Server=.;Database=GameTracker;MultipleActiveResultSets=True;Trusted_Connection=True;"));
//builder.Services.AddDbContext<GameContext>(opt => opt.UseSq("Server=.;Database=GameTracker;MultipleActiveResultSets=True;Trusted_Connection=True;"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ApplicationScopedExtensions.AddApplicationScopes(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();