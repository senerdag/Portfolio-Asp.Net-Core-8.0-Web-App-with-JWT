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
    public class RemoveDescriptionCommandHandler:IRequestHandler<RemoveDescriptionCommand>
    {
        private readonly IRepository<Description> _repository;

        public RemoveDescriptionCommandHandler(IRepository<Description> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveDescriptionCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
