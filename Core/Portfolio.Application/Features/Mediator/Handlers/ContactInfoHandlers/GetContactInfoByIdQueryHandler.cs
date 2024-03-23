using MediatR;
using Portfolio.Application.Features.Mediator.Queries.ContactInfoQueries;
using Portfolio.Application.Features.Mediator.Results.ContactInfoResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ContactInfoHandlers
{
    public class GetContactInfoByIdQueryHandler:IRequestHandler<GetContactInfoByIdQuery, GetContactInfoByIdQueryResult>
    {
        private readonly IRepository<ContactInfo> _repository;

        public GetContactInfoByIdQueryHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactInfoByIdQueryResult> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetContactInfoByIdQueryResult
            {
                ContactInfoId = values.ContactInfoId,
                Title = values.Title,
                Info = values.Info,
                Icon = values.Icon
            };
        }
    }
}
