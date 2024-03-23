using MediatR;
using Portfolio.Application.Features.Mediator.Queries.ResumeQueries;
using Portfolio.Application.Features.Mediator.Results.ResumeResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.ResumeHandlers
{
    public class GetResumeByIdQueryHandler:IRequestHandler<GetResumeByIdQuery, GetResumeByIdQueryResult>
    {
        private readonly IRepository<Resume> _repository;

        public GetResumeByIdQueryHandler(IRepository<Resume> repository)
        {
            _repository = repository;
        }

        public async Task<GetResumeByIdQueryResult> Handle(GetResumeByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetResumeByIdQueryResult
            {
                ResumeId = values.ResumeId,
                University = values.University,
                Title = values.Title,
                OnYears = values.OnYears,
                CvUrl=values.CvUrl,
                Description = values.Description
            };
        }
    }
}
