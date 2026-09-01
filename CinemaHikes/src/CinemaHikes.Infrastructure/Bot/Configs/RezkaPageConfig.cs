using CinemaHikes.Domain.Interfaces.Bot;
using Microsoft.Playwright;

namespace CinemaHikes.Infrastructure.Bot.Configs;

public class RezkaPageConfig : IPageConfig
{
    public async Task InitPageAsync(IPage page, string pageUrl)
    {
        await page.GotoAsync(pageUrl, new PageGotoOptions()
        {
            WaitUntil = WaitUntilState.DOMContentLoaded,
            Timeout = 60000
        });

        await page.WaitForTimeoutAsync(3500);
    }
}