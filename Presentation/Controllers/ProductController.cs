using Contract.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Common;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int productId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductService.GetById(productId, cancellationToken);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto productDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductService.Create(productDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("update/{productId}")]
        public async Task<IActionResult> Update(int productId, [FromBody] ProductUpdateDto productDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductService.Update(productId, productDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> Delete(int productId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductService.Delete(productId, cancellationToken);
            return Ok(response);
        }
    }
}
