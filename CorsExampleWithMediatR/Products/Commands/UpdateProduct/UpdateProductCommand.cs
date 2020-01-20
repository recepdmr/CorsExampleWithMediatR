using CorsExampleWithMediatR.Entities;
using MediatR;

namespace CorsExampleWithMediatR.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
