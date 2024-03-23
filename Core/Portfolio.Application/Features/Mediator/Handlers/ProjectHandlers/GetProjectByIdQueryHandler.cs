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
    public class GetProjectByIdQueryHandler:IRequestHandler<GetProjectByIdQuery,GetProjectByIdQueryResult>
    {
        private readonly IRepository<Project> _repository;

        public GetProjectByIdQueryHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task<GetProjectByIdQueryResult> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetProjectByIdQueryResult
            {
                ProjectId = values.ProjectId,
                Name = values.Name,
                JobTitle = values.JobTitle,
                CoverImageUrl = values.CoverImageUrl
            };
        }
    }
}
