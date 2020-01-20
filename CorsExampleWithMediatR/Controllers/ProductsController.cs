using CorsExampleWithMediatR.Products.Commands.InsertProduct;
using CorsExampleWithMediatR.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CorsExampleWithMediatR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new GetProductsCommand()));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]InsertProductCommand insertProductCommand)
        {
            return Ok(await _mediator.Send(insertProductCommand));
        }
    }
}
