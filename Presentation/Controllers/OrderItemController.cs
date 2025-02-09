using Contract.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/order-items")]
    public class OrderItemController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderItemService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{orderItemId}")]
        public async Task<IActionResult> GetById(int orderItemId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderItemService.GetById(orderItemId, cancellationToken);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] OrderItemCreateDto orderItemDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderItemService.Create(orderItemDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("update/{orderItemId}")]
        public async Task<IActionResult> Update(int orderItemId, [FromBody] OrderItemUpdateDto orderItemDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderItemService.Update(orderItemId, orderItemDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("delete/{orderItemId}")]
        public async Task<IActionResult> Delete(int orderItemId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderItemService.Delete(orderItemId, cancellationToken);
            return Ok(response);
        }
    }
}
