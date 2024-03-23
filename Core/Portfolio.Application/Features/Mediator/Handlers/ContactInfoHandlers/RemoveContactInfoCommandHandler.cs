using MediatR;
using Portfolio.Application.Features.Mediator.Commands.ContactInfoCommands;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ContactInfoHandlers
{
    public class RemoveContactInfoCommandHandler:IRequestHandler<RemoveContactInfoCommand>
    {
        private readonly IRepository<ContactInfo> _repository;

        public RemoveContactInfoCommandHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
