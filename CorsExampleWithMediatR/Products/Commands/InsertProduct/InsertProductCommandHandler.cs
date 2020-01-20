using AutoMapper;
using CorsExampleWithMediatR.Entities;
using CorsExampleWithMediatR.Persistance.EfCore;
using CorsExampleWithMediatR.Persistance.EfCore.Contexts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CorsExampleWithMediatR.Products.Commands.InsertProduct
{
    public partial class InsertProductCommand
    {
        public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, Product>
        {
            private readonly ILogger<InsertProductCommandHandler> _logger;
            private readonly ITestDbContext _testDbContext;
            private readonly IMapper _mapper;
            public InsertProductCommandHandler(ILogger<InsertProductCommandHandler> logger, ITestDbContext testDbContext, IMapper mapper)
            {
                _logger = logger;
                _testDbContext = testDbContext;
                _mapper = mapper;
            }

            public async Task<Product> Handle(InsertProductCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var product = _mapper.Map<Product>(request);

                    using (var transactionScope = new TransactionScope())
                    {

                        await _testDbContext.Products.AddAsync(product, cancellationToken);
                        await _testDbContext.SaveChangeAsync(cancellationToken);
                        transactionScope.Complete();
                    }

                    return product;
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex.Message);
                    throw ex;
                }
            }
        }
    }
}
