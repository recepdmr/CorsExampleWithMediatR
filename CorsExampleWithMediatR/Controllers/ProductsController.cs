using CorsExampleWithMediatR.Products.Commands.InsertProduct;
using CorsExampleWithMediatR.Products.Commands.UpdateProduct;
using CorsExampleWithMediatR.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CorsExampleWithMediatR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;

            _logger.LogError("TEST");
        }
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


        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateProductCommand updateProductCommand)
        {
            return Ok(await _mediator.Send(updateProductCommand));
        }
    }
}
