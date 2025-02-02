using Domain.Entities;

namespace Domain.Abstraction.Services;
public interface IJwtProvider
{
    string Generate(User user);
}