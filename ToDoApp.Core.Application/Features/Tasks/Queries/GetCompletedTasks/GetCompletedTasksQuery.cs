using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Core.Application.Intefaces.Repositories;
using ToDoApp.Core.Application.Wrappers;

namespace ToDoApp.Core.Application.Features.Tasks.Queries.GetCompletedTasks
{
    public class GetCompletedTasksQuery : IRequest<PagedResponse<IEnumerable<GetCompletedTasksViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetCompletedTasksQueryHandler : IRequestHandler<GetCompletedTasksQuery, PagedResponse<IEnumerable<GetCompletedTasksViewModel>>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        private readonly IMapper _mapper;
        public GetCompletedTasksQueryHandler(ITaskRepositoryAsync taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<GetCompletedTasksViewModel>>> Handle(GetCompletedTasksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetCompletedTasksParameter>(request);
            var tasks = await _taskRepository.GetPagedCompletedTasks(validFilter.PageNumber, validFilter.PageSize);
            var taskViewModels = _mapper.Map<IEnumerable<GetCompletedTasksViewModel>>(tasks);
            return new PagedResponse<IEnumerable<GetCompletedTasksViewModel>>(taskViewModels, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
