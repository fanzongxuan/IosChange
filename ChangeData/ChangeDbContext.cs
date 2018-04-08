using Microsoft.EntityFrameworkCore;
using Change.Data.Data;

namespace Change.Data
{
    public class ChangeDbContext : DbContext
    {
        public DbSet<Machine> Machine { get; set; }

        public DbSet<MachineParamter> MachineParamter { get; set; }

        public DbSet<ImpactBudleId> ImpactBudleId { get; set; }

        public DbSet<ChangeRecord> ChangeRecord { get; set; }

        public DbSet<ReUseRecord> ReUseRecord { get; set; }

        public DbSet<AppStoreAccount> AppStoreAccount { get; set; }

        public DbSet<AccountUserRecord> AccountUserRecord { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<ProductionRecord> ProductionRecord { get; set; }

        public DbSet<DaliyProduction> DailyProductionRecord { get; set; }

        public ChangeDbContext(DbContextOptions<ChangeDbContext> options) : base(options)
        {
        }
    }
}

