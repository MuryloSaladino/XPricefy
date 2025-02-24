namespace Server.Application.Features.Products.Edit;

public sealed record EditProductResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    decimal Price,
    int ClientsNumber,
    int YearsToPay
);