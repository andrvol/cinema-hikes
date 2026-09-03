using CinemaHikes.Domain.Enums;

namespace CinemaHikes.Domain.Entities.Catalog;

public sealed class VideoSource
{
    public int Id { get; set; }

    public required int MovieId { get; set; }
    public required Movie Movie { get; set; }

    public required string ProviderName { get; set; }

    public required string PageUrl { get; set; }

    public required short Priority { get; set; }

    public required SourceStatus Status { get; set; }
}