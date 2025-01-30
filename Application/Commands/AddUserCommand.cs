using MediatR;

namespace Application.Commands;
public class AddUserCommand : IRequest<Guid>
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}