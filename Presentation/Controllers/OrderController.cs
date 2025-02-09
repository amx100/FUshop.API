using Contract.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(int orderId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderService.GetById(orderId, cancellationToken);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] OrderCreateDto orderDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderService.Create(orderDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("update/{orderId}")]
        public async Task<IActionResult> Update(int orderId, [FromBody] OrderUpdateDto orderDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderService.Update(orderId, orderDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("delete/{orderId}")]
        public async Task<IActionResult> Delete(int orderId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OrderService.Delete(orderId, cancellationToken);
            return Ok(response);
        }
    }
}
