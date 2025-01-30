﻿using Application.Abstraction.IRepositories;
using Dapper;
using System.Data;

namespace Persistence.Repositories;

public class TaskRepository : BaseRepository<Task>, ITaskRepository
{
    public async Task<IEnumerable<Task>> GetTasksByProjectAsync(IDbConnection connection, Guid projectId)
    {
        var sql = "SELECT * FROM Tasks WHERE ProjectId = @ProjectId";
        return await connection.QueryAsync<Task>(sql, new { ProjectId = projectId });
    }

    public async Task<IEnumerable<Task>> GetTasksByStateAsync(IDbConnection connection, Guid stateId)
    {
        var sql = "SELECT * FROM Tasks WHERE StateId = @StateId";
        return await connection.QueryAsync<Task>(sql, new { StateId = stateId });
    }
}
