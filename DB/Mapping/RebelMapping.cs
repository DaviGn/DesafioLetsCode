using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Mapping
{
    internal class RebelMapping : IEntityTypeConfiguration<Rebel>
    {
        public void Configure(EntityTypeBuilder<Rebel> builder)
        {
            builder.ToTable("Rebel");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.GalaxyName).IsRequired().HasMaxLength(80);
            builder.Property(x => x.ReportCount).IsRequired();
        }
    }
}
