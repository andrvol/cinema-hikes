using Microsoft.Playwright;

namespace CinemaHikes.Domain.Interfaces.Bot;

public interface IBrowserConfig
{
    public BrowserTypeLaunchOptions CreateLaunchOptions();
    
    public BrowserNewContextOptions CreateContextOptions();
}