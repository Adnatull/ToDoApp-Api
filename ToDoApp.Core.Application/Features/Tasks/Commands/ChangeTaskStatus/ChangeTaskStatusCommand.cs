using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Core.Application.Exceptions;
using ToDoApp.Core.Application.Intefaces.Repositories;
using ToDoApp.Core.Application.Wrappers;

namespace ToDoApp.Core.Application.Features.Tasks.Commands.UpdateTaskStatus
{
    public class ChangeTaskStatusCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class ChangeTaskStatusCommandHandler : IRequestHandler<ChangeTaskStatusCommand, Response<int>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        public ChangeTaskStatusCommandHandler(ITaskRepositoryAsync taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Response<int>> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if(task == null)
            {
                throw new ApiException($"Task Not Found.");
            } else
            {
                task.IsCompleted = !task.IsCompleted;
                await _taskRepository.UpdateAsync(task);
                return new Response<int>(task.Id);
            }
        }
    }
}
