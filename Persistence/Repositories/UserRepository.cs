﻿using Application.Abstraction;
using Application.Abstraction.IRepositories;
using Dapper;
using Domain.Entities;
using System.Data;

namespace Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ISqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    { }

    public async Task<User?> GetByLoginAsync(string login)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = "SELECT * FROM Users WHERE Login = @Login";
        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Login = login });
    }

    public async Task<IEnumerable<User>> GetUsersByProjectAsync(Guid projectId)
    {
        using var connection = _connectionFactory.CreateConnection();
        var sql = @"
            SELECT u.* 
            FROM Users u
            JOIN UserProjects up ON u.Id = up.UserId
            WHERE up.ProjectId = @ProjectId";
        return await connection.QueryAsync<User>(sql, new { ProjectId = projectId });
    }
}
