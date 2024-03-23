using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Mediator.Commands.SkillCommands;
using Portfolio.Application.Features.Mediator.Queries.SkillQueries;

namespace Portfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> SkillList()
        {
            var values = await _mediator.Send(new GetSkillQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkill(int id)
        {
            var value = await _mediator.Send(new GetSkillByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSkill(CreateSkillCommand command)
        {
            await _mediator.Send(command);
            return Ok("Skill Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSkill(int id)
        {
            await _mediator.Send(new RemoveSkillCommand(id));
            return Ok("Skill Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSkill(UpdateSkillCommand command)
        {
            await _mediator.Send(command);
            return Ok("Skill Güncellendi");
        }
    }
}
