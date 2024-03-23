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
    public class UpdateContactCommandHandler:IRequestHandler<UpdateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ContactId);
            values.SendDate = DateTime.UtcNow;
            values.Email = request.Email;
            values.Message = request.Message;
            values.Subject = request.Subject;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
