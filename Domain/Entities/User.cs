namespace Domain.Entities;
public class User : BaseEntity
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}