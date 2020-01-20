using CorsExampleWithMediatR.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CorsExampleWithMediatR.Persistance.EfCore
{
    public interface ITestDbContext
    {
        public DbSet<Product> Products { get; set; }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
    }
}
