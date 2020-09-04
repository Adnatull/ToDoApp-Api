using AutoMapper;
using System.Threading.Tasks;
using ToDoApp.Core.Application.Features.Tasks.Commands.CreateTask;
using ToDoApp.Core.Application.Features.Tasks.Queries.GetAllIncompleteTasks;
using ToDoApp.Core.Application.Features.Tasks.Queries.GetAllTasks;
using ToDoApp.Core.Application.Features.Tasks.Queries.GetCompletedTasks;
using ToDoApp.Core.Application.Features.Tasks.Queries.GetTaskById;

namespace ToDoApp.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Domain.Entities.Task, GetAllTasksViewModel>().ReverseMap();
            CreateMap<Domain.Entities.Task, GetIncompleteTasksViewModel>().ReverseMap();
            CreateMap<Domain.Entities.Task, GetCompletedTasksViewModel>().ReverseMap();
            CreateMap<Domain.Entities.Task, GetTaskByIdViewModel>().ReverseMap();
            CreateMap<CreateTaskCommand, Domain.Entities.Task>().ForMember(dest => dest.IsCompleted, act => act.MapFrom(src => 1 == 1 ? false : false));
            CreateMap<GetAllTasksQuery, GetAllTasksParameter>();
            CreateMap<GetIncompleteTasksQuery, GetIncompleteTasksParameter>();
            CreateMap<GetCompletedTasksQuery, GetCompletedTasksParameter>();
        }
    }
}
