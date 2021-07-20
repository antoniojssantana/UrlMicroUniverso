using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using url.business.Models;


namespace url.data.Context
{
    public class URLDbContext : DbContext
    {
        public DbSet<UserBaseModel> UsersBase { get; set; }
        public URLDbContext(DbContextOptions<URLDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                    .SelectMany(e => e.GetProperties())
                                    .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(100)");
            }

            foreach (var relations in modelBuilder.Model.GetEntityTypes()
                                                    .SelectMany(r => r.GetForeignKeys()))
            {
                relations.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(URLDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreateDate").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}