using HowLongToBeat.Api.Models;

namespace HowLongToBeat.Mvc.Models;

public record HomeViewModel
(
    IList<Game> Games
);