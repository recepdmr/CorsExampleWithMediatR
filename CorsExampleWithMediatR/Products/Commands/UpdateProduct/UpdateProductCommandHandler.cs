using AutoMapper;
using CorsExampleWithMediatR.Entities;
using CorsExampleWithMediatR.Persistance.EfCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CorsExampleWithMediatR.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ITestDbContext _testDbContext;
        public UpdateProductCommandHandler(ITestDbContext testDbContext, ILogger<UpdateProductCommandHandler> logger, IMapper mapper)
        {
            _testDbContext = testDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(request);

                var updatedEntity = ((DbContext)_testDbContext).Entry(product);

                updatedEntity.State = EntityState.Modified;


                await _testDbContext.SaveChangeAsync(cancellationToken);

                return updatedEntity.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
