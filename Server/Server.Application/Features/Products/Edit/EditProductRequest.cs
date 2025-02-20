using MediatR;

namespace Server.Application.Features.Products.Edit;

public sealed record EditProductRequest(
    string Id,
    string Name,
    float AnnualPrice,
    int ClientsNumber,
    int YearsToPay
) : IRequest<EditProductResponse>;