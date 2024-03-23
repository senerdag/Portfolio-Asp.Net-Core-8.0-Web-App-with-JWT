using MediatR;
using Portfolio.Application.Features.Mediator.Results.ContactInfoResults;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.ContactInfoQueries
{
    public class GetContactInfoQuery:IRequest<List<GetContactInfoQueryResult>>
    {
    }
}
