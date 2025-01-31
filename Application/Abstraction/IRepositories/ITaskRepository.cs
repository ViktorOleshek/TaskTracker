using Task = Domain.Entities.Task;

namespace Application.Abstraction.IRepositories;
public interface ITaskRepository : IRepository<Task>
{
    Task<IEnumerable<Task>> GetTasksByProjectAsync(Guid projectId);
    Task<IEnumerable<Task>> GetTasksByStateAsync(Guid stateId);
}