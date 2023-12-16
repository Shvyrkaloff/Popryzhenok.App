using System.Data.Entity;
using Popryzhenok.App.Models;

namespace Popryzhenok.App
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DBConnection")
        {

        }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Factory> Factories { get; set; }

        public DbSet<HistoryOfReleaseProduct> HistoryOfReleaseProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<MinCostChangeHistory> MinCostChangeHistory { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<RequestOnProduct> RequestOnProducts { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Transfer> Transfers { get; set; }
    }
}
