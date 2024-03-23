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
    public class UpdateResumeCommandHandler:IRequestHandler<UpdateResumeCommand>
    {
        private readonly IRepository<Resume> _repository;

        public UpdateResumeCommandHandler(IRepository<Resume> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateResumeCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ResumeId);
            values.Description = request.Description;
            values.University = request.University;
            values.Title = request.Title;
            values.CvUrl = request.CvUrl;
            values.OnYears = request.OnYears;
            await _repository.UpdateAsync(values);
        }
    }
}
