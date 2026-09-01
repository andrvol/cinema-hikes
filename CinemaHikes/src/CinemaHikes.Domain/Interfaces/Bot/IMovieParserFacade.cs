namespace CinemaHikes.Domain.Interfaces.Bot;

public interface IMovieParserFacade
{
    public Task<string> GetMovieSrc(string pageUrl, string videoQuality);
}