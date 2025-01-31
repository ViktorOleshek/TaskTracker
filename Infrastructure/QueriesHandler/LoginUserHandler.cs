using Application.Abstraction.IRepositories;
using Application.Abstraction.IServices;
using Application.Queries;
using MediatR;

namespace Infrastructure.QueriesHandler;
public class LoginUserHandler : IRequestHandler<LoginUserQuery, LoginUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginUserHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginUserResult> Handle(LoginUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByLoginAsync(query.Login);

        if (user is null || !BCrypt.Net.BCrypt.Verify(query.Password, user.Password))
        {
            throw new Exception("Invalid credentials");
        }

        string token = _jwtProvider.Generate(user);

        return new LoginUserResult
        {
            Id = user.Id,
            Email = user.Email,
            Token = token
        };
    }
}
