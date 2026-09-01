using Microsoft.Playwright;

namespace CinemaHikes.Domain.Interfaces.Bot;

public interface IBrowserFactory
{
    public Task<IPage> CreatePageAsync(IBrowserConfig browserConfig);
    
    public Task DisposeAsync();
}