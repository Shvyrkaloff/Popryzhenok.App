using System.Data.Entity;
using Popryzhenok.App.Models;

namespace Popryzhenok.App
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DBConnection")
        {

        }

        DbSet<Agent> Agents { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<Factory> Factories { get; set; }

        DbSet<HistoryOfReleaseProduct> HistoryOfReleaseProducts { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Material> Materials { get; set; }

        DbSet<MinCostChangeHistory> MinCostChangeHistory { get; set; }

        DbSet<Offer> Offers { get; set; }

        DbSet<Provider> Providers { get; set; }

        DbSet<RequestOnProduct> RequestOnProducts { get; set; }

        DbSet<Size> Sizes { get; set; }

        DbSet<Transfer> Transfers { get; set; }
    }
}
