using Microsoft.Playwright;
using TelegramBotDownloader.Application.Interfaces;
using TelegramBotDownloader.Infrastructure.Providers;

namespace TelegramBotDownloader.Infrastructure.Configs;

public class RandomBrowserConfig : IBrowserConfig
{
    public BrowserTypeLaunchOptions CreateLaunchOptions()
    {
        return new BrowserTypeLaunchOptions()
        {
            Headless = true,
            Args =
            [
                "--headless=new",
                "--disable-blink-features=AutomationControlled",
                "--no-sandbox",
                "--disable-setuid-sandbox",
                "--disable-infobars"
            ]
        };
    }

    public BrowserNewContextOptions CreateContextOptions()
    {
        var profile = BrowserProfileProvider.GetRandomProfile();

        return new BrowserNewContextOptions
        {
            UserAgent = profile.UserAgent,
            ViewportSize = profile.Viewport,
            Locale = profile.Locale,
            TimezoneId = profile.TimezoneId,
            ExtraHTTPHeaders = profile.ToExtraHttpHeaders()
        };
    }
}