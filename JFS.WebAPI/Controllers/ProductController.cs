using JFS.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JFS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateProductCommand), new {id = result.Data.Id});
        }
    }
}
