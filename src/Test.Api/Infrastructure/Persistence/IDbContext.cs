using Microsoft.EntityFrameworkCore;
using Test.Api.Domain.Entities;

namespace Test.Api.Infrastructure.Persistence
{
    public interface IDbContext
    {
        public DbSet<User> Users { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
