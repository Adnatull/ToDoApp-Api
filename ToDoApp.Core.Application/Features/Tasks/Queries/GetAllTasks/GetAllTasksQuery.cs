using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Core.Application.Intefaces.Repositories;
using ToDoApp.Core.Application.Wrappers;

namespace ToDoApp.Core.Application.Features.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<PagedResponse<IEnumerable<GetAllTasksViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, PagedResponse<IEnumerable<GetAllTasksViewModel>>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        private readonly IMapper _mapper;

        public GetAllTasksQueryHandler(ITaskRepositoryAsync taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<GetAllTasksViewModel>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllTasksParameter>(request);
            var tasks = await _taskRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var taskViewModels = _mapper.Map<IEnumerable<GetAllTasksViewModel>>(tasks);
            return new PagedResponse<IEnumerable<GetAllTasksViewModel>>(taskViewModels, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
