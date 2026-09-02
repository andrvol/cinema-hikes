namespace CinemaHikes.Domain.Entities.Catalog;

public sealed class MovieGenre
{
    public int Id { get; set; }
    
    public int MovieId { get; set; }
    public required Movie Movie { get; set; }
    
    public int GenreId { get; set; }
    public required Genre Genre { get; set; }
}