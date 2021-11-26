using DB.Mapping;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { 
        }

        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<Rebel> Rebel { get; set; }
        public DbSet<RebelInventory> RebelInventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InventoryItemMapping());
            modelBuilder.ApplyConfiguration(new RebelMapping());
            modelBuilder.ApplyConfiguration(new RebelInventoryMapping());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
