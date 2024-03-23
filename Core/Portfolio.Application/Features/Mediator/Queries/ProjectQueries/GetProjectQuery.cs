using MediatR;
using Portfolio.Application.Features.Mediator.Results.ProjectResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.ProjectQueries
{
    public class GetProjectQuery:IRequest<List<GetProjectQueryResult>>
    {
    }
}
