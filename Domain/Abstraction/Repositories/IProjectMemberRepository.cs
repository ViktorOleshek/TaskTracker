using Domain.Entities;

namespace Domain.Abstraction.Repositories;
public interface IProjectMemberRepository : IRepository<ProjectMember>
{
    Task<ProjectMember?> GetRoleByUserAndProjectAsync(Guid userId, Guid projectId);
}