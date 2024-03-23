using MediatR;
using Portfolio.Application.Features.Mediator.Results.AppUserResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetCheckAppUserQuery:IRequest<GetCheckAppUserQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
