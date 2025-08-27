using FortressAuth.Domain.Entities;
using FortressAuth.Domain.Entities.Base;
using FortressAuth.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FortressAuth.Infraestructure.Data
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }

        private void ConfigureSave()
        {
            this.ChangeTracker.DetectChanges();

            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is DefaultEntityNoKey && (e.State == EntityState.Added || e.State == EntityState.Modified));

            DateTime dhNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                DefaultEntityNoKey entity = (DefaultEntityNoKey)entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entity.SetDhChange(DateTime.UtcNow);
                        break;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ConfigureSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<RefreshTokenUser> RefreshTokensUser { get; set; }
    }
}
