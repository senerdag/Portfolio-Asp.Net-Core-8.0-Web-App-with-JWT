using MediatR;
using Portfolio.Application.Features.Mediator.Queries.BannerQueries;
using Portfolio.Application.Features.Mediator.Results.BannerResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler:IRequestHandler<GetBannerQuery,List<GetBannerQueryResult>>
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                SideTitle= x.SideTitle,
               CoverImageUrl = x.CoverImageUrl,
               Description = x.Description,
               Title = x.Title
            }).ToList();
        }
    }
}
