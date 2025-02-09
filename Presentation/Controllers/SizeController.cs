using Contract.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Common;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/sizes")]
    public class SizeController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await serviceManager.SizeService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{sizeId}")]
        public async Task<IActionResult> GetById(int sizeId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.SizeService.GetById(sizeId, cancellationToken);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SizeCreateDto sizeDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.SizeService.Create(sizeDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("update/{sizeId}")]
        public async Task<IActionResult> Update(int sizeId, [FromBody] SizeUpdateDto sizeDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.SizeService.Update(sizeId, sizeDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("delete/{sizeId}")]
        public async Task<IActionResult> Delete(int sizeId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.SizeService.Delete(sizeId, cancellationToken);
            return Ok(response);
        }
    }
}
