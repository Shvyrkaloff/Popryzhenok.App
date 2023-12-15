using System;

namespace Popryzhenok.App.Models
{
    public class HistoryOfReleaseProduct
    {
        public int Id { get; set; }

        public int? AgentID { get; set; }

        public virtual Agent? Agent { get; set; }

        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
