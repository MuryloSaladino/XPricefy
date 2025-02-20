namespace Server.Domain.Common;

public class UserSession(string username, string id)
{
    public string Username { get; set; } = username;
    public Guid Id { get; set; } = Guid.Parse(id);
}