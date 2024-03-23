using MediatR;
using Portfolio.Application.Features.Mediator.Queries.ServiceQueries;
using Portfolio.Application.Features.Mediator.Results.ServiceResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler:IRequestHandler<GetServiceQuery,List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                Title = x.Title,
                Icon = x.Icon,
                ServiceId=x.ServiceId
            }).ToList();
        }
    }
}
