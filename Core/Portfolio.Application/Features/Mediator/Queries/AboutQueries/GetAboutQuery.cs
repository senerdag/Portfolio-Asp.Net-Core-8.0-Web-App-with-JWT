using MediatR;
using Portfolio.Application.Features.Mediator.Results.AboutResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutQuery:IRequest<List<GetAboutQueryResult>>
    {
    }
}
