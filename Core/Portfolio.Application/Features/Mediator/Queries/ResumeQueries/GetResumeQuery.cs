using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Features.Mediator.Results.ResumeResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.ResumeQueries
{
    public class GetResumeQuery:IRequest<List<GetResumeQueryResult>>
    {
    }
}
