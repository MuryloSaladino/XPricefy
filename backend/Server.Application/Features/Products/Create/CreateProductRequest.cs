using MediatR;

namespace Server.Application.Features.Products.Create;

public sealed record CreateProductRequest(
    string Name,
    decimal Price,
    int ClientsNumber,
    int YearsToPay
) : IRequest<CreateProductResponse>;