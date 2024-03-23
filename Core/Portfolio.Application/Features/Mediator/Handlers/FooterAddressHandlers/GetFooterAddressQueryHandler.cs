using MediatR;
using Portfolio.Application.Features.Mediator.Queries.FooterAddressQueries;
using Portfolio.Application.Features.Mediator.Queries.FooterAddressQueries;
using Portfolio.Application.Features.Mediator.Results.FooterAddressResults;
using Portfolio.Application.Features.Mediator.Results.FooterAddressResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler:IRequestHandler<GetFooterAddressQuery,List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                FooterAddressId = x.FooterAddressId,
                Email = x.Email,
                Address = x.Address,
                Description = x.Description,
                Phone = x.Phone
            }).ToList();
        }
    }
}
