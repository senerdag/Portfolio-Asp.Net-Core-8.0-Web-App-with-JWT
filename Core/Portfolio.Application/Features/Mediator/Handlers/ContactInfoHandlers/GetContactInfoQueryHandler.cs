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

namespace Portfolio.Application.Features.Mediator.Handlers.ContactInfoInfoHandlers
{
    public class GetContactInfoQueryHandler:IRequestHandler<GetContactInfoQuery,List<GetContactInfoQueryResult>>
    {
        private readonly IRepository<ContactInfo> _repository;

        public GetContactInfoQueryHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactInfoQueryResult>> Handle(GetContactInfoQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactInfoQueryResult
            {
                ContactInfoId = x.ContactInfoId,
                Icon=x.Icon,
                Info = x.Info,
                Title = x.Title
            }).ToList();
        }
    }
}
