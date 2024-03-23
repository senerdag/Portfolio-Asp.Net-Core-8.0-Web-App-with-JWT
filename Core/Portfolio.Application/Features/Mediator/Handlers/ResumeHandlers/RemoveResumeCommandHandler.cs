using MediatR;
using Portfolio.Application.Features.Mediator.Commands.ResumeCommands;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ResumeHandlers
{
    public class RemoveResumeCommandHandler:IRequestHandler<RemoveResumeCommand>
    {
        private readonly IRepository<Resume> _repository;

        public RemoveResumeCommandHandler(IRepository<Resume> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveResumeCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
