using Domain.Abstraction.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Commands;
public class AddUserHandler : IRequestHandler<AddUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByLoginAsync(request.Login);
        if (existingUser is not null)
        {
            throw new InvalidOperationException("User with this login exists");
        }

        var user = new User
        {
            Email = request.Email,
            Login = request.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        return await _userRepository.CreateAsync(user);
    }
}