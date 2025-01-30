using System.Data;
using Task = Domain.Entities.Task;

namespace Application.Abstraction.IRepositories;
public interface ITaskRepository : IRepository<Task>
{
    Task<IEnumerable<Task>> GetTasksByProjectAsync(IDbConnection connection, Guid projectId);
    Task<IEnumerable<Task>> GetTasksByStateAsync(IDbConnection connection, Guid stateId);
}