using CinemaHikes.Domain.Interfaces.Bot;
using Microsoft.Playwright;

namespace CinemaHikes.Infrastructure.Bot.Factories;

public class PlaywrightBrowserFactory : IBrowserFactory
{
    private IPlaywright? _playwright;
    
    private IBrowser? _browser;
    
    private IBrowserContext? _context;
    
    public async Task<IPage> CreatePageAsync(IBrowserConfig browserConfig)
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(browserConfig.CreateLaunchOptions());
        _context = await _browser.NewContextAsync(browserConfig.CreateContextOptions());
        
        await _context.AddInitScriptAsync(@"
            Object.defineProperty(navigator, 'webdriver', { get: () => undefined });
            Object.defineProperty(navigator, 'languages', { get: () => ['ru-RU', 'ru', 'en-US', 'en'] });
            Object.defineProperty(navigator, 'plugins', { get: () => [1, 2, 3, 4, 5] });
            window.chrome = { runtime: {} };
        ");
        
        return await _context.NewPageAsync();
    }

    public async Task DisposeAsync()
    {
        if (_browser is not null)
            await _browser.DisposeAsync();
        
        _playwright?.Dispose();
    }
}