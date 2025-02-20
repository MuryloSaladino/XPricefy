namespace Server.Application.Features.Products.Find;

public sealed record FindProductResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    float AnnualPrice,
    int ClientsNumber,
    int YearsToPay
);