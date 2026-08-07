using Microsoft.Playwright;
using TelegramBotDownloader.Infrastructure.Configs;

namespace TelegramBotDownloader.Infrastructure.Providers;

public static class BrowserProfileProvider
{
    private static readonly Random Random = new();

    private static readonly List<BrowserProfileConfig> Profiles = new()
    {
        new BrowserProfileConfig(
            UserAgent:
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36",
            Platform: "MacIntel",
            SecChUaPlatform: "\"macOS\"",
            Viewport: new ViewportSize { Width = 1440, Height = 900 },
            Locale: "ru-RU",
            TimezoneId: "Europe/Kyiv"
        ),

        new BrowserProfileConfig(
            UserAgent:
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36",
            Platform: "MacIntel",
            SecChUaPlatform: "\"macOS\"",
            Viewport: new ViewportSize { Width = 1680, Height = 1050 },
            Locale: "ru-RU",
            TimezoneId: "Europe/Kiev"
        ),

        new BrowserProfileConfig(
            UserAgent:
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36",
            Platform: "Win32",
            SecChUaPlatform: "\"Windows\"",
            Viewport: new ViewportSize { Width = 1920, Height = 1080 },
            Locale: "ru-RU",
            TimezoneId: "Europe/Kyiv"
        ),

        new BrowserProfileConfig(
            UserAgent:
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36",
            Platform: "Win32",
            SecChUaPlatform: "\"Windows\"",
            Viewport: new ViewportSize { Width = 2560, Height = 1440 },
            Locale: "ru-RU",
            TimezoneId: "Europe/Kiev"
        )
    };

    public static BrowserProfileConfig GetRandomProfile()
    {
        int index = Random.Next(Profiles.Count);
        return Profiles[index];
    }
}