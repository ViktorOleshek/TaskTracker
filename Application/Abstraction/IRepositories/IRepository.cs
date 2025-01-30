using System.Data;

namespace Application.Abstraction.IRepositories;
public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync(IDbConnection connection);
    Task<T?> GetByIdAsync(IDbConnection connection, Guid id);
    Task<int> CreateAsync(IDbConnection connection, T entity);
    Task<int> UpdateAsync(IDbConnection connection, T entity);
    Task<int> DeleteAsync(IDbConnection connection, Guid id);
}