using Microsoft.EntityFrameworkCore;
using Change.Data.Data;

namespace Change.Data
{
    public class ChangeDbContext : DbContext
    {
        public DbSet<Machine> Machine { get; set; }

        public DbSet<MachineParamter> MachineParamter { get; set; }

        public DbSet<ImpactBudleId> ImpactBudleId { get; set; }

        public ChangeDbContext(DbContextOptions<ChangeDbContext> options) : base(options)
        {
        }
    }
}

