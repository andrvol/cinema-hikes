using CinemaHikes.Domain.Interfaces.Bot.Parsers;
using Microsoft.Playwright;

namespace CinemaHikes.Infrastructure.Bot.Parsers.Rezka;

public class RezkaGearIconParser : IPageElementParser
{
    public async Task ParseElementAsync(IPage page)
    {
        await WaitForVideoReadyAsync(page);

        var gearIcon = page.Locator("#oframecdnplayer > pjsdiv:nth-child(17) > pjsdiv:nth-child(3)");
        await gearIcon.ClickAsync(new LocatorClickOptions() { Force = true });
        await Task.Delay(800);
    }

    private async Task WaitForVideoReadyAsync(IPage page)
    {
        await page.Locator("video")
            .WaitForAsync(new LocatorWaitForOptions()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 15000
            });
    }
}