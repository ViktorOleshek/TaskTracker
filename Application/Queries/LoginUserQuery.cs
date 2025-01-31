using MediatR;

namespace Application.Queries;
public class LoginUserQuery : IRequest<LoginUserResult>
{
    public LoginUserQuery(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public string Login { get; set; }
    public string Password { get; set; }
}