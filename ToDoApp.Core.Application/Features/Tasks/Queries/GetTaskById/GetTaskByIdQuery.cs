using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Core.Application.Exceptions;
using ToDoApp.Core.Application.Intefaces.Repositories;
using ToDoApp.Core.Application.Wrappers;

namespace ToDoApp.Core.Application.Features.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<Response<GetTaskByIdViewModel>>
    {
        public int Id { get; set; }
    }
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Response<GetTaskByIdViewModel>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        private readonly IMapper _mapper;
        public GetTaskByIdQueryHandler(ITaskRepositoryAsync taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<Response<GetTaskByIdViewModel>> Handle(GetTaskByIdQuery query, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(query.Id);
            if (task == null) throw new ApiException($"Task Not Found.");
            var taskViewModel = _mapper.Map<GetTaskByIdViewModel>(task);
            return new Response<GetTaskByIdViewModel>(taskViewModel);
        }
    }
}
