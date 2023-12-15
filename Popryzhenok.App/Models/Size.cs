namespace Popryzhenok.App.Models
{
    public class Size
    {
        public int Id { get; set; }
        public int? Height { get; set; }

        public int? Width { get; set; }

        public int? Lenght { get; set; }

        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
