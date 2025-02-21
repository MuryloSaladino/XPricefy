using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Features.Products.Find;

public sealed record FindProductResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    float AnnualPrice,
    int ClientsNumber,
    int YearsToPay,
    List<ProductHistoryResponse> ProductHistories 
);

public sealed record ProductHistoryResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    Guid UserId,
    Guid ProductId,
    HistoryAction Action 
);