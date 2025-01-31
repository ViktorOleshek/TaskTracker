using Domain.Entities;

namespace Application.Abstraction.IServices;
public interface IJwtProvider
{
    string Generate(User user);
}