using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    internal static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>().HasData(new InventoryItem()
            {
                Id = 1,
                Name = "Arma",
                Points = 4
            }, new InventoryItem()
            {
                Id = 2,
                Name = "Munição",
                Points = 3
            }, new InventoryItem()
            {
                Id = 3,
                Name = "Água",
                Points = 2
            }, new InventoryItem()
            {
                Id = 4,
                Name = "Comida",
                Points = 1
            });
        }
    }
}
