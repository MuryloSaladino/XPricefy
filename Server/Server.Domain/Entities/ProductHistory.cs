using Server.Domain.Enums;

namespace Server.Domain.Entities;

public class ProductHistory
{
    public Guid Id { get; } = Guid.NewGuid();
    public required HistoryAction Action;
    public required DateTime Date = DateTime.Now;
    public string? Description;
    public required User User;
    public required Product Product;
}