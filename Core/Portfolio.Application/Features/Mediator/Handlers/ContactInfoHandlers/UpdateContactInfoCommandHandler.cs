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
    public class UpdateContactInfoCommandHandler:IRequestHandler<UpdateContactInfoCommand>
    {
        private readonly IRepository<ContactInfo> _repository;

        public UpdateContactInfoCommandHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ContactInfoId);
            values.Info=request.Info;
            values.Title=request.Title;
            values.Icon=request.Icon;
            await _repository.UpdateAsync(values);
        }
    }
}
