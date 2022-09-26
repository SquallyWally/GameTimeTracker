using HowLongToBeat.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HowLongToBeat.Api.Context;
using HowLongToBeat.Api.Models;
using HowLongToBeat.Api.TrackerService;
using HowLongToBeat.Mvc.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HowLongToBeat.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly GameContext _context;
    private readonly ApiConsumeService _apiConsumeService;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, GameContext context, ApiConsumeService apiConsumeService)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _context = context;
        _apiConsumeService = apiConsumeService;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Games";
        const string uri = "api/Game";

        var client = _httpClientFactory.CreateClient(name: "HowLongToBeat.Api");
        HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
        var response = await client.SendAsync(request);
        
        var model = await response.Content.ReadFromJsonAsync<IEnumerable<Game>>();

        // HttpResponseMessage res = _apiConsumeService.GetResponse(uri);
        // res.EnsureSuccessStatusCode();
        // var games = await res.Content.ReadFromJsonAsync<IEnumerable<Game>>();
        
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> UpdateGame(int id)
    {
        var stringId = id.ToString(); 
        const string uri = "$api/Game/?id={stringId}";
        HttpResponseMessage response = _apiConsumeService.GetResponse(uri);
        response.EnsureSuccessStatusCode();
        var model = await response.Content.ReadFromJsonAsync<IEnumerable<Game>>();
        ViewBag.Title = "All Products";
        return View(model);
    }
}