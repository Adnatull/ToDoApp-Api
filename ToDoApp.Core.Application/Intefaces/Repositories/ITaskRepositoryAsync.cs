using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Core.Application.Intefaces.Repositories
{
    public interface ITaskRepositoryAsync : IGenericRepositoryAsync<Domain.Entities.Task>
    {
        Task<List<Domain.Entities.Task>> GetIncompleteTasks();
        Task<List<Domain.Entities.Task>> GetPagedIncompleteTasks(int pageNumber, int pageSize);
        Task<List<Domain.Entities.Task>> GetCompletedTasks();
        Task<List<Domain.Entities.Task>> GetPagedCompletedTasks(int pageNumber, int pageSize);
    }
}
