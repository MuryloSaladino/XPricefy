namespace Server.Application.Features.Products.Create;

public sealed record CreateProductResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    decimal Price,
    int ClientsNumber,
    int YearsToPay
);