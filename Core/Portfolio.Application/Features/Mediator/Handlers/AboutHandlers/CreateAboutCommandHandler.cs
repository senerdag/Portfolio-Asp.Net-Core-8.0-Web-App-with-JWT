using MediatR;
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
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new About
            {
                Address = request.Address,
                CompleteProject = request.CompleteProject,
                CvUrl = request.CvUrl,
                DateOfBirth = request.DateOfBirth,
                Description = request.Description,
                CoverImageUrl = request.CoverImageUrl,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                ZipCode = request.ZipCode,

            });
            
        }
    }
}
