using MediatR;
using Portfolio.Application.Features.Mediator.Commands.ProjectCommands;
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
    public class UpdateProjectCommandHandler:IRequestHandler<UpdateProjectCommand>
    {
        private readonly IRepository<Project> _repository;

        public UpdateProjectCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ProjectId);
            values.CoverImageUrl = request.CoverImageUrl;
            values.Name = request.Name;
            values.JobTitle = request.JobTitle;
            await _repository.UpdateAsync(values);
        }
    }
}
