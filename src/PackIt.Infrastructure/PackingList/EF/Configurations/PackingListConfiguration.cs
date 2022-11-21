using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PackIt.Infrastructure.PackingList.EF.Configurations;

internal sealed class PackingListConfiguration : 
    IEntityTypeConfiguration<Domain.Entities.PackingList>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.PackingList> builder)
    {
        builder.HasKey(pl => pl.Id);

        builder.OwnsOne(pl => pl.Localization,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(country => country.Country)
                    .HasColumnName("Country")
                    .IsRequired();
                navigationBuilder
                    .Property(city => city.City)
                    .HasColumnName("City")
                    .IsRequired();
            });

        builder.OwnsOne(pl => pl.Name,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(n => n.Value)
                    .HasColumnName("Name")
                    .IsRequired();
            });

        builder.OwnsOne(pl => pl.Temperature,
            navigationBuilder =>
            {
                navigationBuilder
                    .Property(t => t.Value)
                    .HasColumnName("Temperature")
                    .IsRequired();
            });

        builder.OwnsMany(pl => pl.Items);

        builder.ToTable("PackingLists");
    }
}
