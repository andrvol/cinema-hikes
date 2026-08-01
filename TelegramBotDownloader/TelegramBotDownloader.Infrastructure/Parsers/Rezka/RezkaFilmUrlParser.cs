using Microsoft.Playwright;
using TelegramBotDownloader.Application.Interfaces.Parsers;

namespace TelegramBotDownloader.Infrastructure.Parsers.Rezka;

public class RezkaFilmUrlParser : IFilmUrlParser
{
    public async Task<string> GetFilmUrlAsync(IPage page, string videoQuality)
    {
        int choiceId = GetVideoIdByQuality(videoQuality);

        await ProceedQualityElementAsync(page, choiceId);
        await ReloadPageAsync(page);

        var videoElement = await page.QuerySelectorAsync("video") ?? throw new NullReferenceException("No film found on the page.");

        string url = await videoElement.GetAttributeAsync("src") ?? throw new NullReferenceException("No film URL found on the page.");

        return CleanUrl(url);
    }

    private int GetVideoIdByQuality(string videoQuality)
    {
        int id;
        switch (videoQuality)
        {
            case "360p":
                id = 1;
                break;
            case "480p":
                id = 2;
                break;
            case "720p":
                id = 3;
                break;
            case "1080p":
                id = 4;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(videoQuality), "No such video quality.");
        }

        return id;
    }

    private async Task ProceedQualityElementAsync(IPage page, int choiceId)
    {
        var qualityElement = page.Locator($"pjsdiv[f2id=\'{choiceId}\']");

        await qualityElement.WaitForAsync(new LocatorWaitForOptions()
        {
            State = WaitForSelectorState.Attached,
            Timeout = 5000
        });

        await qualityElement.ClickAsync(new LocatorClickOptions() { Force = true });
        await Task.Delay(1000);
    }

    private async Task ReloadPageAsync(IPage page)
    {
        await page.ReloadAsync(new PageReloadOptions()
        {
            WaitUntil = WaitUntilState.DOMContentLoaded,
            Timeout = 60000
        });

        await Task.Delay(new Random().Next(2000, 5000));
    }

    private string CleanUrl(string url)
    {
        int lastIndex = 1;
        
        for (int i = 0; i < url.Length; i++)
        {
            if (url[i] == '4')
            {
                if (url[i - 1] == 'p' && url[i - 2] == 'm' && url[i - 3] == '.')
                {
                    lastIndex += i;
                    break;
                }
            }
        }
        
        return url[..lastIndex];
    }
}