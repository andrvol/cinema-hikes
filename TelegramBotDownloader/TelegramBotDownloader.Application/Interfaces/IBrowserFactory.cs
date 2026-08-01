using Microsoft.Playwright;

namespace TelegramBotDownloader.Application.Interfaces;

public interface IBrowserFactory
{
    public Task<IPage> CreatePageAsync(IBrowserConfig browserConfig);
    public Task DisposeAsync();
}