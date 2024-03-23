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
    public class GetDescriptionByIdQueryHandler:IRequestHandler<GetDescriptionByIdQuery, GetDescriptionByIdQueryResult>
    {
        private readonly IRepository<Description> _repository;

        public GetDescriptionByIdQueryHandler(IRepository<Description> repository)
        {
            _repository = repository;
        }

        public async Task<GetDescriptionByIdQueryResult> Handle(GetDescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetDescriptionByIdQueryResult
            {
                DescriptionId = values.DescriptionId,
                MainDescription = values.MainDescription,
                Name= values.Name
            };
        }
    }
}
