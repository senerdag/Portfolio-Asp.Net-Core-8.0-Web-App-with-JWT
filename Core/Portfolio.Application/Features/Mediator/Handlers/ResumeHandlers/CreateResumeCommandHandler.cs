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
    public class CreateResumeCommandHandler:IRequestHandler<CreateResumeCommand>
    {
        private readonly IRepository<Resume> _repository;

        public CreateResumeCommandHandler(IRepository<Resume> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateResumeCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Resume
            {
                Description = request.Description,
                OnYears = request.OnYears,
                Title = request.Title,
                CvUrl = request.CvUrl,
                University = request.University               
            });

        }
    }
}
