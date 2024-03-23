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
    public class RemoveSkillCommandHandler:IRequestHandler<RemoveSkillCommand>
    {
        private readonly IRepository<Skill> _repository;

        public RemoveSkillCommandHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSkillCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
