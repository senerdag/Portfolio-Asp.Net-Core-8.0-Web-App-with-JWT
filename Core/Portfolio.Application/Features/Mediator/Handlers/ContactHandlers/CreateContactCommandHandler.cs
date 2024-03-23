using MediatR;
using Portfolio.Application.Features.Mediator.Commands.ContactCommands;
using Portfolio.Application.Features.Mediator.Commands.ContactCommands;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler:IRequestHandler<CreateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Contact
            {
                Message = request.Message,
                Email = request.Email,
                Name = request.Name,
                SendDate = request.SendDate,
                Subject = request.Subject
            });

        }
    }
}
