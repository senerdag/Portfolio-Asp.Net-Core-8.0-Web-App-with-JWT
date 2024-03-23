using MediatR;
using Portfolio.Application.Features.Mediator.Queries.ContactQueries;
using Portfolio.Application.Features.Mediator.Queries.ContactQueries;
using Portfolio.Application.Features.Mediator.Results.ContactResults;
using Portfolio.Application.Features.Mediator.Results.ContactResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler:IRequestHandler<GetContactByIdQuery,GetContactByIdQueryResult>
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = values.ContactId,
                Subject = values.Subject,
                SendDate = values.SendDate,
                Name = values.Name, 
                Email = values.Email,
                Message = values.Message
            };
        }
    }
}
