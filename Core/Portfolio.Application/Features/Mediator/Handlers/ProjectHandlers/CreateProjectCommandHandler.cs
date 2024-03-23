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
    public class CreateProjectCommandHandler:IRequestHandler<CreateProjectCommand>
    {
        private readonly IRepository<Project> _repository;

        public CreateProjectCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Project
            {
                CoverImageUrl = request.CoverImageUrl,
                JobTitle = request.JobTitle,
                Name = request.Name
            });

        }
    }
}
