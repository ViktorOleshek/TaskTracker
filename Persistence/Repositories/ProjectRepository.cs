using Application.Abstraction;
using Application.Abstraction.IRepositories;
using Dapper;
using Domain.Entities;
using System.Data;

namespace Persistence.Repositories;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(ISqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    { }

    public async Task<IEnumerable<Project>> GetProjectsByUserAsync(IDbConnection connection, Guid userId)
    {
        var sql = @"
            SELECT p.* 
            FROM Projects p
            JOIN UserProjects up ON p.Id = up.ProjectId
            WHERE up.UserId = @UserId";

        return await connection.QueryAsync<Project>(sql, new { UserId = userId });
    }
}
