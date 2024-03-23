using MediatR;
using Portfolio.Application.Features.Mediator.Queries.AboutQueries;
using Portfolio.Application.Features.Mediator.Results.AboutResults;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutId = x.AboutId,
                Address = x.Address,
                CompleteProject = x.CompleteProject,
                CvUrl = x.CvUrl,
                CoverImageUrl=x.CoverImageUrl,
                DateOfBirth = x.DateOfBirth,
                Description = x.Description,
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                ZipCode = x.ZipCode
            }).ToList();
        }
    }
}
