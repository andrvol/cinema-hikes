using Microsoft.Playwright;

namespace TelegramBotDownloader.Application.Interfaces.Parsers;

public interface IFilmUrlParser
{
    public Task<string> GetFilmUrlAsync(IPage page, string videoQuality);
}