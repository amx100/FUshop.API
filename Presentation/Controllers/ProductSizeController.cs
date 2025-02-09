using Contract.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Common;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/product-sizes")]
    public class ProductSizeController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductSizeService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{productSizeId}")]
        public async Task<IActionResult> GetById(int productSizeId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductSizeService.GetById(productSizeId, cancellationToken);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProductSizeCreateDto productSizeDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductSizeService.Create(productSizeDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("update/{productSizeId}")]
        public async Task<IActionResult> Update(int productSizeId, [FromBody] ProductSizeUpdateDto productSizeDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductSizeService.Update(productSizeId, productSizeDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("delete/{productSizeId}")]
        public async Task<IActionResult> Delete(int productSizeId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ProductSizeService.Delete(productSizeId, cancellationToken);
            return Ok(response);
        }
    }
}
