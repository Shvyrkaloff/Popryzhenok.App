namespace Popryzhenok.App.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string? Articul { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public byte[]? Image { get; set; }

        public decimal? MinPrice { get; set; }

        public double? WeightNetto { get; set; }

        public double? WeightBrutto { get; set; }

        public string? Sertificate { get; set; }

        public string? Standard { get; set; }

        public int? Count { get; set; }

        public int? FactoryId { get; set;}

        public virtual Factory? Factory { get; set; }
    }
}
