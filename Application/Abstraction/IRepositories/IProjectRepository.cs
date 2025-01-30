using Domain.Entities;

namespace Application.Abstraction.IRepositories;
public interface IProjectRepository : IRepository<Project>
{
    Task<IEnumerable<Project>> GetProjectsByUserAsync(Guid userId);
}