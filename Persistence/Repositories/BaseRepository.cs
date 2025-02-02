using Domain.Abstraction;
using Domain.Abstraction.Repositories;
using Dapper;
using Domain.Entities;
using static Dapper.SimpleCRUD;

namespace Persistence.Repositories;
internal abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly ISqlConnectionFactory _connectionFactory;

    public BaseRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.GetListAsync<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.GetAsync<TEntity>(id);
    }

    public virtual async Task<Guid> CreateAsync(TEntity entity)
    {
        using var connection = _connectionFactory.CreateConnection();
        await connection.InsertAsync(entity);
        return entity.Id;
    }

    public virtual async Task<int> UpdateAsync(TEntity entity)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.UpdateAsync(entity);
    }

    public virtual async Task<int> DeleteAsync(Guid id)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.DeleteAsync<TEntity>(id);
    }
}