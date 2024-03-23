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
    public class GetResumeQueryHandler:IRequestHandler<GetResumeQuery,List<GetResumeQueryResult>>
    {
        private readonly IRepository<Resume> _repository;

        public GetResumeQueryHandler(IRepository<Resume> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetResumeQueryResult>> Handle(GetResumeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetResumeQueryResult
            {
                ResumeId = x.ResumeId,
                Description = x.Description,
                OnYears = x.OnYears,
                Title = x.Title,
                CvUrl= x.CvUrl,
                University = x.University
            }).ToList();
        }
    }
}
