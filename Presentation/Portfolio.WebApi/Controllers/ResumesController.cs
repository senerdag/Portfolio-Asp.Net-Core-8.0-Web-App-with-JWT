using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Mediator.Commands.ResumeCommands;
using Portfolio.Application.Features.Mediator.Queries.ResumeQueries;

namespace Portfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResumesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ResumeList()
        {
            var values = await _mediator.Send(new GetResumeQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResume(int id)
        {
            var value = await _mediator.Send(new GetResumeByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateResume(CreateResumeCommand command)
        {
            await _mediator.Send(command);
            return Ok("Resume Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveResume(int id)
        {
            await _mediator.Send(new RemoveResumeCommand(id));
            return Ok("Resume Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateResume(UpdateResumeCommand command)
        {
            await _mediator.Send(command);
            return Ok("Resume Güncellendi");
        }
    }
}
