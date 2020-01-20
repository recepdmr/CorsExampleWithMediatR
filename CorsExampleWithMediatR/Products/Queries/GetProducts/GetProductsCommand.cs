using CorsExampleWithMediatR.Entities;
using MediatR;
using System.Collections.Generic;

namespace CorsExampleWithMediatR.Products.Queries.GetProducts
{
    public class GetProductsCommand : IRequest<List<Product>>
    {
        
    }
}
