namespace Popryzhenok.App.Models
{
    public class RequestOnProduct
    {

        public int Id { get; set; }

        public int? AgentId { get; set; }

        public virtual Agent? Agent { get; set; }

        public int ManagerId { get; set; }

        public virtual Employee Manager { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
