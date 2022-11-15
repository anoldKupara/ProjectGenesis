using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Models.Entities;

namespace ProjectGenesis.Data
{
    public class ProjectGenesisDbContext : DbContext
    {
        public ProjectGenesisDbContext(DbContextOptions<ProjectGenesisDbContext> options) : base(options)
        {
        }

        public DbSet<BirdCategory> BirdCategories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<User> Users { get; set; }  


    }
}
