using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Core.Application.Intefaces.Repositories;
using ToDoApp.Domain.Entities;
using ToDoApp.Infrastructure.Persistence.Context;

namespace ToDoApp.Infrastructure.Persistence.Repositories
{
    public class TaskRepositoryAsync : GenericRepositoryAsync<Task>, ITaskRepositoryAsync
    {
        private readonly DbSet<Task> _tasks;
        public TaskRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _tasks = dbContext.Set<Task>();
        }

        public async System.Threading.Tasks.Task<List<Task>> GetCompletedTasks()
        {
            return await _tasks.Where(x => x.IsCompleted == true).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<Task>> GetIncompleteTasks()
        {
            return await _tasks.Where(x => x.IsCompleted == false).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<Task>> GetPagedCompletedTasks(int pageNumber, int pageSize)
        {
            return await _tasks.Where(x => x.IsCompleted == true)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<Task>> GetPagedIncompleteTasks(int pageNumber, int pageSize)
        {
            return await _tasks.Where(x => x.IsCompleted == false)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .AsNoTracking()
                        .ToListAsync();
        }
    }
}
