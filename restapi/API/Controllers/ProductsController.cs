using MediatR;
using Microsoft.AspNetCore.Mvc;
using restapi.Application.Commands;
using restapi.Application.Queries;
using restapi.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }
    }
}
