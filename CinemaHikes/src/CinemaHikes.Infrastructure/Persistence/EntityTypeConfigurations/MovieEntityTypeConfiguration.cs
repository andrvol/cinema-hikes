using CinemaHikes.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaHikes.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();

        builder.Property(m => m.RuTitle)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(m => m.UaTitle)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(m => m.RuInEngTitle)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(m => m.Description)
            .HasMaxLength(350)
            .IsRequired();

        builder.Property(m => m.Director)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(m => m.ReleaseYear)
            .IsRequired();

        builder.Property(m => m.PosterUrl)
            .HasMaxLength(350)
            .IsRequired();

        builder.Property(m => m.KpRating)
            .HasColumnType("numeric(3,1)")
            .IsRequired();

        builder.Property(m => m.CreatedAt)
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.HasIndex(m => m.RuTitle)
            .HasMethod("gin")
            .HasOperators("gin_trgm_ops")
            .IsUnique();

        builder.HasIndex(m => m.UaTitle)
            .HasMethod("gin")
            .HasOperators("gin_trgm_ops")
            .IsUnique();

        builder.HasIndex(m => m.RuInEngTitle)
            .HasMethod("gin")
            .HasOperators("gin_trgm_ops")
            .IsUnique();

        builder.ToTable(m => m.HasCheckConstraint(
            name: "CK__Movie__RuTitle",
            sql: $"LEN({nameof(Movie.RuTitle)}) > 0"));

        builder.ToTable(m => m.HasCheckConstraint(
            name: "CK__Movie__UaTitle",
            sql: $"LEN({nameof(Movie.UaTitle)}) > 0"));

        builder.ToTable(m => m.HasCheckConstraint(
            name: "CK__Movie__RuInEngTitle",
            sql: $"LEN({nameof(Movie.RuInEngTitle)}) > 0"));

        builder.ToTable(m => m.HasCheckConstraint(
            name: "CK__Movie__Description",
            sql: $"LEN({nameof(Movie.Description)}) > 0"));

        builder.ToTable(m => m.HasCheckConstraint(
            name: "CK__Movie__Director",
            sql: $"LEN({nameof(Movie.Director)}) > 0"));

        builder.ToTable(m => m.HasCheckConstraint(
            name: "CK__Movie__PosterUrl",
            sql: $"LEN({nameof(Movie.PosterUrl)}) > 0"));
    }
}