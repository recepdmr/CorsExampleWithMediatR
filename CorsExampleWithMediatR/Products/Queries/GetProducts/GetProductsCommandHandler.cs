using CorsExampleWithMediatR.Entities;
using CorsExampleWithMediatR.Persistance.EfCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CorsExampleWithMediatR.Products.Queries.GetProducts
{
    public class GetProductsCommandHandler : IRequestHandler<GetProductsCommand, List<Product>>
    {
        private readonly ITestDbContext _testDbContext;

        public GetProductsCommandHandler(ITestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public Task<List<Product>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            return _testDbContext.Products.ToListAsync(cancellationToken);
        }
    }
}
