namespace Domain.Models
{
    public class RebelInventory
    {
        public int RebelId { get; set; }
        public virtual Rebel Rebel { get; set; }
        public int ItemId { get; set; }
        public virtual InventoryItem Item { get; set; }
        public int Count { get; set; }
    }
}
