using MediatR;
using Portfolio.Application.Features.Mediator.Queries.SkillQueries;
using Portfolio.Application.Features.Mediator.Results.SkillResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.SkillHandlers
{
    public class GetSkillByIdQueryHandler:IRequestHandler<GetSkillByIdQuery, GetSkillByIdQueryResult>
    {
        private readonly IRepository<Skill> _repository;

        public GetSkillByIdQueryHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task<GetSkillByIdQueryResult> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetSkillByIdQueryResult
            {
                SkillId = values.SkillId,
                Progress = values.Progress,
                Name=values.Name
            };
        }
    }
}
