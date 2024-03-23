using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Mediator.Commands.DescriptionCommands;
using Portfolio.Application.Features.Mediator.Queries.DescriptionQueries;

namespace Portfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> DescriptionList()
        {
            var values = await _mediator.Send(new GetDescriptionQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDescription(int id)
        {
            var value = await _mediator.Send(new GetDescriptionByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDescription(CreateDescriptionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Description Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDescription(int id)
        {
            await _mediator.Send(new RemoveDescriptionCommand(id));
            return Ok("Description Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDescription(UpdateDescriptionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Description Güncellendi");
        }
    }
}
