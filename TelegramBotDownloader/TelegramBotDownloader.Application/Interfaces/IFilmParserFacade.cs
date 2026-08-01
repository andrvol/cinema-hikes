namespace TelegramBotDownloader.Application.Interfaces;

public interface IFilmParserFacade
{
    public Task<string> GetFilmSrc(string pageUrl, string videoQuality);
}