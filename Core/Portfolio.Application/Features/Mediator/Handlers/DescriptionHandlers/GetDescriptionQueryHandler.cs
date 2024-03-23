using MediatR;
using Portfolio.Application.Features.Mediator.Queries.DescriptionQueries;
using Portfolio.Application.Features.Mediator.Results.DescriptionResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.DescriptionHandlers
{
    public class GetDescriptionQueryHandler:IRequestHandler<GetDescriptionQuery,List<GetDescriptionQueryResult>>
    {
        private readonly IRepository<Description> _repository;

        public GetDescriptionQueryHandler(IRepository<Description> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetDescriptionQueryResult>> Handle(GetDescriptionQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetDescriptionQueryResult
            {
                DescriptionId = x.DescriptionId,
                MainDescription = x.MainDescription,
                Name=x.Name,
            }).ToList();
        }
    }
}
