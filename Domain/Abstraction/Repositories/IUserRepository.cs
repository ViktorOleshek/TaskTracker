using Domain.Entities;

namespace Domain.Abstraction.Repositories;
public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByLoginAsync(string login);
    Task<IEnumerable<User>> GetUsersByProjectAsync(Guid projectId);
}