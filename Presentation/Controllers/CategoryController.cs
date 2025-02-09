using Contract.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await serviceManager.CategoryService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetById(int categoryId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.CategoryService.GetById(categoryId, cancellationToken);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.CategoryService.Create(categoryDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("update/{categoryId}")]
        public async Task<IActionResult> Update(int categoryId, [FromBody] CategoryUpdateDto categoryDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.CategoryService.Update(categoryId, categoryDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("delete/{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.CategoryService.Delete(categoryId, cancellationToken);
            return Ok(response);
        }
    }
}
