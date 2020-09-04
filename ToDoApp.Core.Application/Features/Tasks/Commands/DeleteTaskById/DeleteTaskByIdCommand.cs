using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Core.Application.Exceptions;
using ToDoApp.Core.Application.Intefaces.Repositories;
using ToDoApp.Core.Application.Wrappers;

namespace ToDoApp.Core.Application.Features.Tasks.Commands.DeleteTaskById
{
    public class DeleteTaskByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteTaskByIdCommandHandler : IRequestHandler<DeleteTaskByIdCommand, Response<int>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;

        public DeleteTaskByIdCommandHandler(ITaskRepositoryAsync taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Response<int>> Handle(DeleteTaskByIdCommand command, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(command.Id);
            if (task == null) throw new ApiException($"Task Not Found.");
            await _taskRepository.DeleteAsync(task);
            return new Response<int>(task.Id);
        }
    }
}
