namespace Popryzhenok.App.Models
{
    public class Material
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public int? CountInBox { get; set; }

        public string? Unit { get; set; }

        public int? CountInStorage { get; set; }

        public int? MinCountInBox { get; set; }

        public string? Description { get; set; }

        public byte[]? Image { get; set; }

        public decimal? Price { get; set; }
    }
}
