using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Mediator.Commands.AboutCommands;
using Portfolio.Application.Features.Mediator.Queries.AboutQueries;

namespace Portfolio.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _mediator.Send(new GetAboutQuery());
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _mediator.Send(new GetAboutByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok("About Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return Ok("About Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok("About Güncellendi");
        }
    }
}
