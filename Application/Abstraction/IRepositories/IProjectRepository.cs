using Domain.Entities;
using System.Data;

namespace Application.Abstraction.IRepositories;
public interface IProjectRepository : IRepository<Project>
{
    Task<IEnumerable<Project>> GetProjectsByUserAsync(IDbConnection connection, Guid userId);
}