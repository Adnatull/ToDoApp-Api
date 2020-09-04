using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Core.Application.Intefaces.Repositories;
using ToDoApp.Core.Application.Wrappers;

namespace ToDoApp.Core.Application.Features.Tasks.Queries.GetAllIncompleteTasks
{
    public class GetIncompleteTasksQuery : IRequest<PagedResponse<IEnumerable<GetIncompleteTasksViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetIncompleteTasksQueryHandler : IRequestHandler<GetIncompleteTasksQuery, PagedResponse<IEnumerable<GetIncompleteTasksViewModel>>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        private readonly IMapper _mapper;
        public GetIncompleteTasksQueryHandler(ITaskRepositoryAsync taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<GetIncompleteTasksViewModel>>> Handle(GetIncompleteTasksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetIncompleteTasksParameter>(request);
            var tasks = await _taskRepository.GetPagedIncompleteTasks(validFilter.PageNumber, validFilter.PageSize);
            var taskViewModels = _mapper.Map<IEnumerable<GetIncompleteTasksViewModel>>(tasks);
            return new PagedResponse<IEnumerable<GetIncompleteTasksViewModel>>(taskViewModels, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
