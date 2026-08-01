using Microsoft.Playwright;

namespace TelegramBotDownloader.Application.Interfaces;

public interface IPageConfig
{
    public Task InitPageAsync(IPage page, string pageUrl);
}