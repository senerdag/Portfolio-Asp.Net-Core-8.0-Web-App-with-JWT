using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Features.Mediator.Commands.AboutCommands;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AboutId);
            values.DateOfBirth=request.DateOfBirth;
            values.Description=request.Description;
            values.Address=request.Address;
            values.CoverImageUrl=request.CoverImageUrl;
            values.Phone=request.Phone;
            values.Email=request.Email;
            values.CompleteProject=request.CompleteProject;
            values.CvUrl=request.CvUrl;
            values.Name=request.Name;
            values.ZipCode=request.ZipCode;
            await _repository.UpdateAsync(values);
        }
    }
}
