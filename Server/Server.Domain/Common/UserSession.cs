namespace Server.Domain.Common;

public class UserSession
{
    public string Username { get; set; }
    public Guid Id { get; set; }

    public UserSession(string username, string id)
    {
        Username = username;
        Id = Guid.Parse(id);
    }
}