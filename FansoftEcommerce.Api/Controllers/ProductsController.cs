using FansoftEcommerce.Application.Products.CreateProduct;
using FansoftEcommerce.Application.Products.GetProductById;
using FansoftEcommerce.Application.Products.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FansoftEcommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;
  
    public ProductsController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var command = new GetProductsQuery();
        var data = await _sender.Send(command);
        return Ok(data);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var command = new GetProductByIdQuery(id);
        var data = await _sender.Send(command);

        if (data is null)
            return NotFound();
        
        return Ok(data);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(CreateProductCommand command)
    {
        var data = await _sender.Send(command);
        return Ok(data);
    }
}
