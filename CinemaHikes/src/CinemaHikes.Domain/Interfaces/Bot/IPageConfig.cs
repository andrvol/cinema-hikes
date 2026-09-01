using Microsoft.Playwright;

namespace CinemaHikes.Domain.Interfaces.Bot;

public interface IPageConfig
{
    public Task InitPageAsync(IPage page, string pageUrl);
}