using Domain.Abstraction;
using Domain.Abstraction.Repositories;
using Dapper;
using Domain.Entities;

namespace Persistence.Repositories;

internal class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(ISqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    { }

    public async Task<IEnumerable<Project>> GetProjectsByUserAsync(Guid userId)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = @"
            SELECT p.* 
            FROM Projects p
            JOIN UserProjects up ON p.Id = up.ProjectId
            WHERE up.UserId = @UserId";

        return await connection.QueryAsync<Project>(sql, new { UserId = userId });
    }
}
