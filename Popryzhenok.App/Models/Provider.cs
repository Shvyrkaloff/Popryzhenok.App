namespace Popryzhenok.App.Models
{
    public class Provider
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? MaterialId { get; set; }

        public Material? Material { get; set; }
    }
}
