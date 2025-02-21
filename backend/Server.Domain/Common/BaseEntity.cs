namespace Server.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null!;
}