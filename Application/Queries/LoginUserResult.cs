namespace Application.Queries;
public class LoginUserResult
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}