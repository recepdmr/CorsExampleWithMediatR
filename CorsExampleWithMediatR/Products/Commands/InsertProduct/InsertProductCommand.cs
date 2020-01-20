using CorsExampleWithMediatR.Entities;
using MediatR;

namespace CorsExampleWithMediatR.Products.Commands.InsertProduct
{
    public partial class InsertProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
    }
}
