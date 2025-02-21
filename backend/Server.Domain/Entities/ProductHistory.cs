using Server.Domain.Common;
using Server.Domain.Enums;

namespace Server.Domain.Entities;

public class ProductHistory : BaseEntity
{
    public required HistoryAction Action;
    public string? Description;

    public required Guid UserId { get; set; }
    public required User User;
    
    public required Guid ProductId { get; set; }
    public required Product Product;
}