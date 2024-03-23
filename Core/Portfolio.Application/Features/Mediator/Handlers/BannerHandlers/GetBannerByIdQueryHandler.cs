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
    public class GetBannerByIdQueryHandler:IRequestHandler<GetBannerByIdQuery,GetBannerByIdQueryResult>
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBannerByIdQueryResult
            {
                BannerId = values.BannerId,
                SideTitle= values.SideTitle,
                Title = values.Title,
                Description = values.Description,
                CoverImageUrl = values.CoverImageUrl
            };
        }
    }
}
