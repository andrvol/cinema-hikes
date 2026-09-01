using Microsoft.Playwright;

namespace CinemaHikes.Domain.Interfaces.Bot.Parsers;

public interface IPageElementParser
{
    public Task ParseElementAsync(IPage page);
}