using MediatR;
using Portfolio.Application.Features.Mediator.Results.DescriptionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.DescriptionQueries
{
    public class GetDescriptionQuery:IRequest<List<GetDescriptionQueryResult>>
    {
    }
}
