using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Mapping
{
    internal class RebelInventoryMapping : IEntityTypeConfiguration<RebelInventory>
    {
        public void Configure(EntityTypeBuilder<RebelInventory> builder)
        {
            builder.ToTable("RebelInventory");
            builder.HasKey(x => new { x.RebelId, x.ItemId });

            builder.Property(x => x.Count).IsRequired();

            builder.HasOne(x => x.Rebel).WithMany(x => x.RebelInventory).HasForeignKey(x => x.RebelId);
            builder.HasOne(x => x.Item).WithMany(x => x.RebelIventories).HasForeignKey(x => x.ItemId);
        }
    }
}
