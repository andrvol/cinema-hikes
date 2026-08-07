using Microsoft.Playwright;

namespace TelegramBotDownloader.Infrastructure.Configs;

public record BrowserProfileConfig(
    string UserAgent,
    string Platform,
    string SecChUaPlatform,
    ViewportSize Viewport,
    string Locale,
    string TimezoneId)
{
    public Dictionary<string, string> ToExtraHttpHeaders()
    {
        return new Dictionary<string, string>
        {
            { "sec-ch-ua", "\"Not/A)Brand\";v=\"8\", \"Chromium\";v=\"126\", \"Google Chrome\";v=\"126\"" },
            { "sec-ch-ua-mobile", "?0" },
            { "sec-ch-ua-platform", SecChUaPlatform },
            { "accept-language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7" }
        };
    }
}