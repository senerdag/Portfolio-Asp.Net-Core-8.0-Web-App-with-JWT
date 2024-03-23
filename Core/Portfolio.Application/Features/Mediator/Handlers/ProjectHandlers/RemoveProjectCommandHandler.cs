using MediatR;
using Portfolio.Application.Features.Mediator.Commands.ProjectCommands;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ProjectHandlers
{
    public class RemoveProjectCommandHandler:IRequestHandler<RemoveProjectCommand>
    {
        private readonly IRepository<Project> _repository;

        public RemoveProjectCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveProjectCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
