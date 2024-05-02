using Cinema.Core.TheatersAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Infrastructure.Data.Config;

public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
{
    private const string THEATER_TABLE_NAME = "theater";
    private const string THEATER_PK_NAME = "pk_theater";
    private const string THEATER_UQ_NAME = "uq_theater_name";
    private const int THEATER_ADDRESS_LENGTH = 256;

    public void Configure(EntityTypeBuilder<Theater> builder)
    {
        builder.ToTable(THEATER_TABLE_NAME, schema: DataSchemaConstants.CINEMA_SCHEMA_NAME);

        builder.HasKey(x => x.Id)
            .HasName(THEATER_PK_NAME);
        builder.Property(x => x.Id)
            .HasDefaultValueSql(DataSchemaConstants.DEFAULT_GUID_FUNCTION);

        builder.Property(x => x.Name)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
        builder.HasIndex(x => x.Name)
            .HasDatabaseName(THEATER_UQ_NAME)
            .IsUnique();

        builder.Property(x => x.Address)
            .HasMaxLength(THEATER_ADDRESS_LENGTH);
    }
}
