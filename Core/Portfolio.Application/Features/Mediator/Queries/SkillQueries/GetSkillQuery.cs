using MediatR;
using Portfolio.Application.Features.Mediator.Results.SkillResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.SkillQueries
{
    public class GetSkillQuery:IRequest<List<GetSkillQueryResult>>
    {
    }
}
