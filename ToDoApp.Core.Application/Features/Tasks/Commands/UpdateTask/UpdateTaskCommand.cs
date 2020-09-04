using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Core.Application.Exceptions;
using ToDoApp.Core.Application.Intefaces.Repositories;
using ToDoApp.Core.Application.Wrappers;

namespace ToDoApp.Core.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
    }

    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Response<int>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        public UpdateTaskCommandHandler(ITaskRepositoryAsync taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Response<int>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if(task == null)
            {
                throw new ApiException($"Task Not Found.");
            } else
            {
                task.Title = request.Title;
                task.Description = request.Description;
                task.IsCompleted = request.IsCompleted;
                task.LastModified = DateTime.UtcNow;
                await _taskRepository.UpdateAsync(task);
                return new Response<int>(task.Id);
            }
        }
    }
}
