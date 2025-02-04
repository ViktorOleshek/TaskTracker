using Dapper;
using Domain.Abstraction;
using Domain.Abstraction.Repositories;
using Domain.Entities;

namespace Persistence.Repositories;
internal class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(ISqlConnectionFactory connectionFactory)
        : base(connectionFactory)
    { }

    public async Task<Role?> GetByNameAsync(string name)
    {
        using var connection = _connectionFactory.CreateConnection();

        var query = @"SELECT * FROM [Role]
            WHERE [Name] = @Name";

        return await connection
            .QueryFirstAsync<Role>(query, new { Name = name });
    }
}