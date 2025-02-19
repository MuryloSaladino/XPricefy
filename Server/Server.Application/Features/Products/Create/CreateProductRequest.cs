using MediatR;

namespace Server.Application.Features.Products.Create;

public sealed record CreateProductRequest(
    string Name,
    float AnnualPrice,
    int ClientsNumber,
    int YearsToPay
) : IRequest<CreateProductResponse>;