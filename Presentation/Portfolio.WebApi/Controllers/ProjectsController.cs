using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Mediator.Commands.ProjectCommands;
using Portfolio.Application.Features.Mediator.Queries.ProjectQueries;

namespace Portfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ProjectList()
        {
            var values = await _mediator.Send(new GetProjectQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var value = await _mediator.Send(new GetProjectByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectCommand command)
        {
            await _mediator.Send(command);
            return Ok("Project Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProject(int id)
        {
            await _mediator.Send(new RemoveProjectCommand(id));
            return Ok("Project Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectCommand command)
        {
            await _mediator.Send(command);
            return Ok("Project Güncellendi");
        }
    }
}
