namespace CinemaHikes.Domain.Entities.Catalog;

public sealed class Movie
{
    public int Id { get; set; }

    public required string RuTitle { get; set; }

    public required string UaTitle { get; set; }

    public required string RuInEngTitle { get; set; }

    public required string Description { get; set; }

    public required string Director { get; set; }

    public required short ReleaseYear { get; set; }

    public required string PosterUrl { get; set; }

    public required double KpRating { get; set; }

    public required DateTime CreatedAt { get; set; }
    
    public ICollection<VideoSource> VideoSources { get; set; } = new List<VideoSource>();
}