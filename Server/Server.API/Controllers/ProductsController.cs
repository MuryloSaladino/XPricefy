using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Products.Create;

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
}