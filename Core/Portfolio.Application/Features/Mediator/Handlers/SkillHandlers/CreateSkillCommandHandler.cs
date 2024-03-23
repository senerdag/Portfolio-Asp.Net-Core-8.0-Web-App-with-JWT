using MediatR;
using Portfolio.Application.Features.Mediator.Commands.SkillCommands;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.SkillHandlers
{
    public class CreateSkillCommandHandler:IRequestHandler<CreateSkillCommand>
    {
        private readonly IRepository<Skill> _repository;

        public CreateSkillCommandHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Skill
            {
                Name = request.Name,
                Progress = request.Progress
            });

        }
    }
}
