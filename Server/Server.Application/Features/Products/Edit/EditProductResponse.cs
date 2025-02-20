namespace Server.Application.Features.Products.Edit;

public sealed record EditProductResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    float AnnualPrice,
    int ClientsNumber,
    int YearsToPay
);