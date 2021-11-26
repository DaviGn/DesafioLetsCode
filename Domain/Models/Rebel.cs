using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Rebel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string GalaxyName { get; set; }
        public int ReportCount { get; set; }
        public bool Traitor { get => ReportCount >= 3; }

        public virtual ICollection<RebelInventory> RebelInventory { get; set; }
    }
}
