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
    public class CreateContactInfoCommandHandler:IRequestHandler<CreateContactInfoCommand>
    {
        private readonly IRepository<ContactInfo> _repository;

        public CreateContactInfoCommandHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ContactInfo
            {
                Icon=request.Icon,
                Info=request.Info,
                Title=request.Title

            });

        }
    }
}
