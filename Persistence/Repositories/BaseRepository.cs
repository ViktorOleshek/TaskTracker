using Application.Abstraction.IRepositories;
using System.Data;
using static Dapper.SimpleCRUD;

namespace Persistence.Repositories;
public abstract class BaseRepository<T> : IRepository<T>
{
    protected string TableName => typeof(T).Name + "s"; // Додаємо "s" до імені класу для відповідної таблиці

    public virtual async Task<IEnumerable<T>> GetAllAsync(IDbConnection connection)
    {
        return await connection.GetListAsync<T>();
    }

    public virtual async Task<T?> GetByIdAsync(IDbConnection connection, Guid id)
    {
        return await connection.GetAsync<T>(id);
    }

    public virtual async Task<int> CreateAsync(IDbConnection connection, T entity)
    {
        return (int)await connection.InsertAsync(entity);
    }

    public virtual async Task<int> UpdateAsync(IDbConnection connection, T entity)
    {
        return await connection.UpdateAsync(entity);
    }

    public virtual async Task<int> DeleteAsync(IDbConnection connection, Guid id)
    {
        return await connection.DeleteAsync<T>(id);
    }
}