using Domain.Entities;

namespace Domain.Abstraction.Repositories;
public interface IProjectMemberRepository
{
    System.Threading.Tasks.Task CreateAsync(ProjectMember entity);
    Task<ProjectMember?> GetAsync(Guid userId, Guid projectId);
    Task<Role?> GetRoleAsync(Guid userId, Guid projectId);
    Task<int> UpdateAsync(ProjectMember entity);
    Task<int> DeleteAsync(ProjectMember entity);
    Task<IEnumerable<ProjectMember>> GetAllByProjectIdAsync(Guid projectId);
}