using MediatR;
using Portfolio.Application.Features.Mediator.Results.BannerResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Queries.BannerQueries
{
    public class GetBannerQuery:IRequest<List<GetBannerQueryResult>>
    {
    }
}
