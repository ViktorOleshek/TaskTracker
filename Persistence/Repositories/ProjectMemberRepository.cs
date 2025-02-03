using Dapper;
using Domain.Abstraction;
using Domain.Abstraction.Repositories;
using Domain.Entities;

namespace Persistence.Repositories;
internal class ProjectMemberRepository : BaseRepository<ProjectMember>, IProjectMemberRepository
{
    public ProjectMemberRepository(ISqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    { }

    public async Task<ProjectMember?> GetRoleByUserAndProjectAsync(Guid userId, Guid projectId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<ProjectMember>(
            "SELECT * FROM UserProjects WHERE UserId = @UserId AND ProjectId = @ProjectId",
            new { UserId = userId, ProjectId = projectId });
    }

    public async Task<int> DeleteAsync(ProjectMember entity)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.DeleteAsync(entity);
    }
}