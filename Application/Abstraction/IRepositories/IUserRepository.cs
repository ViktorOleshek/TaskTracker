using Domain.Entities;
using System.Data;

namespace Application.Abstraction.IRepositories;
public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByLoginAsync(IDbConnection connection, string login);
    Task<IEnumerable<User>> GetUsersByProjectAsync(IDbConnection connection, Guid projectId);
}