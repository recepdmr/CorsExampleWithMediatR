using CorsExampleWithMediatR.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace CorsExampleWithMediatR.Persistance.EfCore.Contexts
{
    public class TestDbContext : DbContext, ITestDbContext
    {
        public TestDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
