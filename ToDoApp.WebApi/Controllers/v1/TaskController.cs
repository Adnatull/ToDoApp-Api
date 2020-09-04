using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using ToDoApp.Core.Application.Features.Tasks.Commands.CreateTask;
using ToDoApp.Core.Application.Features.Tasks.Commands.DeleteTaskById;
using ToDoApp.Core.Application.Features.Tasks.Commands.UpdateTask;
using ToDoApp.Core.Application.Features.Tasks.Commands.UpdateTaskStatus;
using ToDoApp.Core.Application.Features.Tasks.Queries.GetAllIncompleteTasks;
using ToDoApp.Core.Application.Features.Tasks.Queries.GetAllTasks;
using ToDoApp.Core.Application.Features.Tasks.Queries.GetCompletedTasks;
using ToDoApp.Core.Application.Features.Tasks.Queries.GetTaskById;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    public class TaskController : BaseApiController
    {
        

        // GET: api/<TaskController>
        [HttpGet("GetAll")]
        public async System.Threading.Tasks.Task<IActionResult> Get([FromQuery] GetAllTasksParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllTasksQuery() { PageSize = filter.PageSize, PageNumber=filter.PageNumber}));
        }

        // GET: api/<TaskController>
        [HttpGet("GetCompletedTasks")]
        public async System.Threading.Tasks.Task<IActionResult> GetCompletedTasks([FromQuery] GetCompletedTasksParameter filter)
        {

            return Ok(await Mediator.Send(new GetCompletedTasksQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET: api/<TaskController>
        [HttpGet("GetIncompleteTasks")]
        public async System.Threading.Tasks.Task<IActionResult> GetIncompleteTasks([FromQuery] GetIncompleteTasksParameter filter)
        {

            return Ok(await Mediator.Send(new GetIncompleteTasksQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTaskByIdQuery() { Id = id }));
        }

        // POST api/<TaskController>
        [HttpPost("Create")]
        public async System.Threading.Tasks.Task<IActionResult> Post( CreateTaskCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}/ChangeStatus")]
        public async System.Threading.Tasks.Task<IActionResult> ChangeStatus(int id,  ChangeTaskStatusCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}/Update")]
        public async System.Threading.Tasks.Task<IActionResult> Update(int id, [FromBody] UpdateTaskCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTaskByIdCommand() { Id = id }));
        }
    }
}
