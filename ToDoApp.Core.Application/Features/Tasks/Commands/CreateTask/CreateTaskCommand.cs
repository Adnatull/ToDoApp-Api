using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Core.Application.Intefaces.Repositories;
using ToDoApp.Core.Application.Wrappers;

namespace ToDoApp.Core.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Response<int>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        private readonly IMapper _mapper;
        public CreateTaskCommandHandler(ITaskRepositoryAsync taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<Domain.Entities.Task>(request);
            await _taskRepository.AddAsync(task);
            return new Response<int>(task.Id);
        }
    }
}
