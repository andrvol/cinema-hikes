using Microsoft.Playwright;

namespace CinemaHikes.Domain.Interfaces.Bot.Parsers;

public interface IMovieUrlParser
{
    public Task<string> GetMovieUrlAsync(IPage page, string videoQuality);
}