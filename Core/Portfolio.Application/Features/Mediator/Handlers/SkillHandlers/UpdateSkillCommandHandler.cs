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
    public class UpdateSkillCommandHandler:IRequestHandler<UpdateSkillCommand>
    {
        private readonly IRepository<Skill> _repository;

        public UpdateSkillCommandHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.SkillId);
            values.Progress=request.Progress;
            values.Name=request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
