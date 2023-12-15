using System;

namespace Popryzhenok.App.Models
{
    public class MinCostChangeHistory
    {
        public int Id { get; set; }

        public string? OldPrice { get; set; }

        public string? NewPrice { get; set;}

        public DateTime? DateTime { get; set; }

        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; } 
    }
}
