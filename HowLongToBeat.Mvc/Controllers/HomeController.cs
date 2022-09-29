using HowLongToBeat.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HowLongToBeat.Api.Models;
using HowLongToBeat.Mvc.Repositories;

namespace HowLongToBeat.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ApiConsumeService _apiConsumeService;

    public HomeController(ApiConsumeService apiConsumeService)
    {
        _apiConsumeService = apiConsumeService;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Games";
        const string uri = "api/Game";

        var response = _apiConsumeService.GetAllResponses(uri);

        var model = await response.Content.ReadFromJsonAsync<IEnumerable<Game>>();

        return View(model);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    public async Task<IActionResult> UpdateGame(string id)
    {
        Game? game = null;
        var uri = $"api/Game/{id}";

        var result = _apiConsumeService.GetResponse(uri);

        if (result.IsSuccessStatusCode)
        {
            game = await result.Content.ReadFromJsonAsync<Game>();
        }

        if (game == null)
        {
            return NotFound();
        }

        return View(game);
    }

    [HttpPost]
    public Task<IActionResult> UpdateGame(Game game)
    {
        var id = game.GameId.ToString();
        var uri = $"api/Game/Edit/{id}";

        var response = _apiConsumeService.PutResponse(uri, game);

        return ResponseToViewHelper(response, out var updateGame)
            ? updateGame
            : Task.FromResult<IActionResult>(View(game));
    }


    public ActionResult AddGame()
    {
        return View();
    }

    [HttpPost]
    public Task<IActionResult> AddGame(Game game)
    {
        const string uri = "api/Game";

        var response = _apiConsumeService.PostResponse(uri, game);

        return ResponseToViewHelper(response, out var addGame)
            ? addGame
            : Task.FromResult<IActionResult>(View(game));
    }

    private bool ResponseToViewHelper(HttpResponseMessage response, out Task<IActionResult> actionResultName)
    {
        if (response.IsSuccessStatusCode)
        {
            actionResultName = Task.FromResult<IActionResult>(RedirectToAction("Index"));
            return true;
        }

        ModelState.AddModelError(string.Empty, "Server error try after some time.");

        actionResultName = null!;
        return false;
    }
}