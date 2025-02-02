using Domain.Entities;

namespace Domain.Abstraction.Repositories;
public interface IProjectRepository : IRepository<Project>
{
    Task<IEnumerable<Project>> GetProjectsByUserAsync(Guid userId);
}