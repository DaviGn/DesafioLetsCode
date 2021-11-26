using System.Collections.Generic;

namespace Domain.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public virtual ICollection<RebelInventory> RebelIventories { get; set; }
    }
}
