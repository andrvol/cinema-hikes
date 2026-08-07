using TelegramBotDownloader.Application.Interfaces;
using TelegramBotDownloader.Application.Interfaces.Parsers;
using TelegramBotDownloader.Infrastructure.Configs;
using TelegramBotDownloader.Infrastructure.Factories;
using TelegramBotDownloader.Infrastructure.Parsers.Rezka;

namespace TelegramBotDownloader.Infrastructure.Facades;

public class RezkaFilmParserFacade : IFilmParserFacade
{
    public async Task<string> GetFilmSrc(string pageUrl, string videoQuality)
    {
        IBrowserConfig kievBrowserConfig = new RandomBrowserConfig();
        
        IBrowserFactory playwrightFactory = new PlaywrightBrowserFactory();
        var page = await playwrightFactory.CreatePageAsync(kievBrowserConfig);

        IPageConfig pageConfig = new RezkaPageConfig();
        await pageConfig.InitPageAsync(page, pageUrl);

        IPageElementParser gearIconParser = new RezkaGearIconParser();
        await gearIconParser.ParseElementAsync(page);

        IPageElementParser qualityMenuParser = new RezkaVideoQualityMenuParser();
        await qualityMenuParser.ParseElementAsync(page);

        IFilmUrlParser filmUrlParser = new RezkaFilmUrlParser();
        string url = await filmUrlParser.GetFilmUrlAsync(page, videoQuality);
        
        return url;
    }
}