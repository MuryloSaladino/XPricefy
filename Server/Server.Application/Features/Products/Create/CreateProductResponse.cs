namespace Server.Application.Features.Products.Create;

public sealed record CreateProductResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime DeletedAt,
    string Name,
    float AnnualPrice,
    int ClientsNumber,
    int YearsToPay
);