namespace Server.Application.Features.Products.FindAll;

public sealed record FindAllProductsResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    decimal Price,
    int ClientsNumber,
    int YearsToPay
);