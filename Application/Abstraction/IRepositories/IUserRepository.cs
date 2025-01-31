using Domain.Entities;

namespace Application.Abstraction.IRepositories;
public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByLoginAsync(string login);
    Task<IEnumerable<User>> GetUsersByProjectAsync(Guid projectId);
}