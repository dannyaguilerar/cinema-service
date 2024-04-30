using Cinema.Core.MoviesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Infrastructure.Data.Config
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public const string MOVIE_TABLE_NAME = "movies";
        public const string MOVIE_PK_NAME = "pk_movie";

        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable(MOVIE_TABLE_NAME, schema: DataSchemaConstants.CINEMA_SCHEMA_NAME);

            builder.HasKey(x => x.Id)
                .HasName(MOVIE_PK_NAME);
            builder.Property(x => x.Id)
                .HasDefaultValueSql(DataSchemaConstants.DEFAULT_GUID_FUNCTION);

            builder.Property(x => x.Title)
                .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

            builder.Property(x => x.Description)
                .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);
        }
    }
}
