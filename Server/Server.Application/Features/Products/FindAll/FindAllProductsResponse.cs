namespace Server.Application.Features.Products.FindAll;

public sealed record FindAllProductsResponse(
    string Id,
    DateTime? UpdatedAt,
    string Name,
    float AnnualPrice
);