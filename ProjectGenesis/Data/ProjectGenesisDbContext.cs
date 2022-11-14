using Microsoft.EntityFrameworkCore;

namespace ProjectGenesis.Data
{
    public class ProjectGenesisDbContext : DbContext
    {
        public ProjectGenesisDbContext(DbContextOptions<ProjectGenesisDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectGenesis.Models.Project> Project { get; set; }
    }
}
