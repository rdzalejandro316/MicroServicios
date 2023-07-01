using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Application.Handlers;
using CQRS.Practico.Infrastructure.Commands;
using CQRS.Practico.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace CQRS.Practico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskItemController : ControllerBase
    {
        public IMediator _mediator;
        public TaskItemController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<TaskItemDto>> Get()
        {
            return await _mediator.Send(new GetAllTasksQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetById(int id)
        {
            var query = new GetTasksByIdQuery(id);
            var taskItem = await _mediator.Send(query);
            return taskItem == null ? NotFound() : taskItem;
        }

        [HttpPost()]
        public async Task<ActionResult<TaskItemDto>> Create(CreateTaskCommand command)
        {
            var taskItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = taskItem.Id }, taskItem);
        }


        [HttpPut()]
        public async Task<IActionResult> Update(int id,UpdateTaskCommand command)
        {
            if (id != command.id) return BadRequest();
            
            var taskItem = await _mediator.Send(command);
            if (taskItem == null) return NotFound();

            return NoContent();
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {            
            var result = await _mediator.Send(new DeleteTaskCommand(id));
            if (!result) return NotFound();

            return NoContent();
        }


    }
}
