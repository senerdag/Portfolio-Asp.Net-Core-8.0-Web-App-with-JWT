﻿using MediatR;
using Portfolio.Application.Features.Mediator.Results.ContactResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.ContactQueries
{
    public class GetContactQuery:IRequest<List<GetContactQueryResult>>
    {
    }
}
