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
    public class GetSkillQueryHandler:IRequestHandler<GetSkillQuery,List<GetSkillQueryResult>>
    {
        private readonly IRepository<Skill> _repository;

        public GetSkillQueryHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSkillQueryResult>> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSkillQueryResult
            {
                SkillId = x.SkillId,
                Name = x.Name,
                Progress = x.Progress
            }).ToList();
        }
    }
}
