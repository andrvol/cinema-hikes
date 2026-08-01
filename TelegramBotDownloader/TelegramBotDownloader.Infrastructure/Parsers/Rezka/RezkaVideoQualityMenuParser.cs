using Microsoft.Playwright;
using TelegramBotDownloader.Application.Interfaces;
using TelegramBotDownloader.Application.Interfaces.Parsers;

namespace TelegramBotDownloader.Infrastructure.Parsers.Rezka;

public class RezkaVideoQualityMenuParser : IPageElementParser
{
    public async Task ParseElementAsync(IPage page)
    {
        await WaitForVideoReadyAsync(page);

        var qualityMenu = page.Locator("pjsdiv", new PageLocatorOptions { HasText = "Качество" }).Nth(5);
        await qualityMenu.ClickAsync(new LocatorClickOptions() { Force = true });
        
        await Task.Delay(800);
    }

    private async Task WaitForVideoReadyAsync(IPage page)
    {
        await page.Locator("video").WaitForAsync(new LocatorWaitForOptions()
        {
            State = WaitForSelectorState.Visible,
            Timeout = 15000
        });
    }
}