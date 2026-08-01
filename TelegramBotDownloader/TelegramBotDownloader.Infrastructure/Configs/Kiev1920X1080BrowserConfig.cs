using Microsoft.Playwright;
using TelegramBotDownloader.Application.Interfaces;

namespace TelegramBotDownloader.Infrastructure.Configs;

public class Kiev1920X1080BrowserConfig : IBrowserConfig
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
        return new BrowserNewContextOptions
        {
            UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36",
            ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
            Locale = "ru-RU",
            TimezoneId = "Europe/Kiev",
            ExtraHTTPHeaders = new Dictionary<string, string>
            {
                { "sec-ch-ua", "\"Not/A)Brand\";v=\"8\", \"Chromium\";v=\"126\", \"Google Chrome\";v=\"126\"" },
                { "sec-ch-ua-mobile", "?0" },
                { "sec-ch-ua-platform", "\"Windows\"" },
                { "accept-language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7" }
            }
        };
    }
}