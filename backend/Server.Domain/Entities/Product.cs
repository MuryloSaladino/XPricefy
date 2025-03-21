using Server.Domain.Common;

namespace Server.Domain.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int ClientsNumber { get; set; }
    public required int YearsToPay { get; set; }
    public required List<ProductHistory> ProductHistories { get; set; } = [];
}