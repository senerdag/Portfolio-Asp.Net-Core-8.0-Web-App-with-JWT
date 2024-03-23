using MediatR;
using Portfolio.Application.Features.Mediator.Results.ResumeResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.ResumeQueries
{
    public class GetResumeByIdQuery:IRequest<GetResumeByIdQueryResult>
    {
        public int Id { get; set; }

        public GetResumeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
