using Microsoft.EntityFrameworkCore;
using Test.Api.Domain.Entities;

namespace Test.Api.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(64).IsRequired();
        }
    }
}
