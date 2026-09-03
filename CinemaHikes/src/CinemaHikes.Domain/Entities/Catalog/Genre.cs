namespace CinemaHikes.Domain.Entities.Catalog;

public sealed class Genre
{
    public int Id { get; set; }

    public required string Name { get; set; }
}