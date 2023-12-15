using System;

namespace Popryzhenok.App.Models
{
    public class Offer
    {
        public int Id { get; set; }

        public int? AgentId { get; set; }

        public virtual Agent? Agent { get; set; }

        public decimal? Price { get; set; }

        public DateTime? DateOfComplete { get; set; }

        public int? ManagerId { get; set; }

        public virtual Employee? Manager { get; set; }

        public int? Count { get; set; }

        public bool? IsPrePaid { get; set; } 

        public bool? IsFullPaid { get; set;}

        public bool? IsDelivery { get; set; }

        public bool? IsChecked { get; set; }
    }
}
