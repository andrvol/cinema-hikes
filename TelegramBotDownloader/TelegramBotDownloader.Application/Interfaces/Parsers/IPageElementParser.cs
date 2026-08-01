using Microsoft.Playwright;

namespace TelegramBotDownloader.Application.Interfaces.Parsers;

public interface IPageElementParser
{
    public Task ParseElementAsync(IPage page);
}