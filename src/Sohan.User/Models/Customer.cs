using OrchardCore.Entities;

namespace Sohan.User.Models;

public class Customer : Entity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
