using MediatR;
using Portfolio.Application.Features.Mediator.Queries.ProjectQueries;
using Portfolio.Application.Features.Mediator.Results.ProjectResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ProjectHandlers
{
    public class GetProjectQueryHandler:IRequestHandler<GetProjectQuery,List<GetProjectQueryResult>>
    {
        private readonly IRepository<Project> _repository;

        public GetProjectQueryHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProjectQueryResult>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetProjectQueryResult
            {
                ProjectId = x.ProjectId,
                CoverImageUrl = x.CoverImageUrl,
                JobTitle = x.JobTitle,
                Name = x.Name
            }).ToList();
        }
    }
}
