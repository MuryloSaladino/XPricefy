using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Products.Create;
using Server.Application.Features.Products.Delete;
using Server.Application.Features.Products.Edit;
using Server.Application.Features.Products.Find;
using Server.Application.Features.Products.FindAll;

namespace Server.API.Controllers;

[ApiController]
[Route("/products")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> CreateProduct(
        CreateProductRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created("/products", response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<FindProductResponse>> FindProduct(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindProductRequest(id), cancellationToken);
        return Ok(response);   
    }

    [HttpGet]
    public async Task<ActionResult<List<FindAllProductsResponse>>> FindAllProducts(
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindAllProductsRequest(), cancellationToken);
        return Ok(response);   
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<EditProductResponse>> EditProduct(
        [FromRoute] string id, EditProductRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteProduct(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteProductRequest(id), cancellationToken);
        return NoContent();
    }
}