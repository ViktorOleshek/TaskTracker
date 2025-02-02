using Domain.Abstraction;
using Domain.Abstraction.Repositories;
using Dapper;
using Task = Domain.Entities.Task;

namespace Persistence.Repositories;

internal class TaskRepository : BaseRepository<Task>, ITaskRepository
{
    public TaskRepository(ISqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    { }
    public async Task<IEnumerable<Task>> GetTasksByProjectAsync(Guid projectId)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = "SELECT * FROM Tasks WHERE ProjectId = @ProjectId";
        return await connection.QueryAsync<Task>(sql, new { ProjectId = projectId });
    }

    public async Task<IEnumerable<Task>> GetTasksByStateAsync(Guid stateId)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = "SELECT * FROM Tasks WHERE StateId = @StateId";
        return await connection.QueryAsync<Task>(sql, new { StateId = stateId });
    }
}
