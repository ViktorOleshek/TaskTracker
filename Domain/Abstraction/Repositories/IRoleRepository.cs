using Domain.Entities;

namespace Domain.Abstraction.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetByNameAsync(string name);
}