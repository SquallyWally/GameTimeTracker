using System.Net.Http.Headers;
using HowLongToBeat.Api.Context;
using HowLongToBeat.Api.Extensions;
using HowLongToBeat.Api.Repositories;
using HowLongToBeat.Api.TrackerService;
using HowLongToBeat.Mvc.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GameContext>(opt =>
    opt.UseSqlServer("Server=.;Database=GameTracker;MultipleActiveResultSets=True;Trusted_Connection=True;"));

ApplicationScopedExtensions.AddApplicationScopes(builder);
builder.Services.AddScoped<ApiConsumeService>();

// Listens to the API
builder.Services.AddHttpClient(name: "HowLongToBeat.Api",
    configureClient: options =>
    {
        options.BaseAddress = new Uri("https://localhost:5002/");
        options.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(
                "application/json", 1.0));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();