using Microsoft.Playwright;

namespace TelegramBotDownloader.Application.Interfaces;

public interface IBrowserConfig
{
    public BrowserTypeLaunchOptions CreateLaunchOptions();
    
    public BrowserNewContextOptions CreateContextOptions();
}