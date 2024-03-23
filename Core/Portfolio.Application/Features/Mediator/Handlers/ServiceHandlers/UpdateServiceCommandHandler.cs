using MediatR;
using Portfolio.Application.Features.Mediator.Commands.ServiceCommands;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler:IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ServiceId);
            values.Title = request.Title;
            values.Icon = request.Icon;
            await _repository.UpdateAsync(values);
        }
    }
}
