using Dapper;
using Domain.Abstraction;
using Domain.Abstraction.Repositories;
using Domain.Entities;

namespace Persistence.Repositories;
internal class ProjectMemberRepository : IProjectMemberRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;
    public ProjectMemberRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async System.Threading.Tasks.Task CreateAsync(ProjectMember entity)
    {
        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(
        @"INSERT INTO ProjectMember(UserId, ProjectId, RoleId)
            VALUES(@UserId, @ProjectId, @RoleId)",
            new { UserId = entity.UserId, ProjectId = entity.ProjectId, RoleId = entity.RoleId });
    }

    public async Task<ProjectMember?> GetAsync(Guid userId, Guid projectId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<ProjectMember>(
            @"SELECT * FROM [Projects] p
            JOIN [UserProjects] up ON p.Id = up.ProjectId
            JOIN [Users] u ON u.Id = up.UserId
            WHERE p.Id = @ProjectId AND up.UserId = @UserId",
            new { UserId = userId, ProjectId = projectId });
    }

    public async Task<Role?> GetRoleAsync(Guid userId, Guid projectId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Role>(
            @"SELECT r.* FROM [Roles] r
            JOIN [UserProjects] up ON r.Id = up.RoleId
            WHERE up.UserId = @UserId AND up.ProjectId = @ProjectId",
            new { UserId = userId, ProjectId = projectId });
    }

    public async Task<int> UpdateAsync(ProjectMember entity)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(
            @"UPDATE UserProjects
            SET RoleId = @RoleId
            WHERE UserId = @UserId AND ProjectId = @ProjectId",
            new { entity.RoleId, entity.UserId, entity.ProjectId });
    }

    public async Task<int> DeleteAsync(ProjectMember entity)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(
            @"DELETE FROM UserProjects
            WHERE UserId = @UserId AND ProjectId = @ProjectId",
            new { entity.UserId, entity.ProjectId });
    }

    public async Task<IEnumerable<ProjectMember>> GetAllByProjectIdAsync(Guid projectId)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<ProjectMember>(
            @"SELECT * FROM UserProjects WHERE ProjectId = @ProjectId",
            new { ProjectId = projectId });
    }
}