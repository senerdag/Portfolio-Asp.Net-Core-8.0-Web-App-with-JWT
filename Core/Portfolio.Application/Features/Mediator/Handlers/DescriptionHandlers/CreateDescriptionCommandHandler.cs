using MediatR;
using Portfolio.Application.Features.Mediator.Commands.DescriptionCommands;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.DescriptionHandlers
{
    public class CreateDescriptionCommandHandler:IRequestHandler<CreateDescriptionCommand>
    {
        private readonly IRepository<Description> _repository;

        public CreateDescriptionCommandHandler(IRepository<Description> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateDescriptionCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Description
            {
                Name = request.Name,
                MainDescription = request.MainDescription
            });

        }
    }
}
