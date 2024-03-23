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
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetAboutByIdQueryResult
            {
                AboutId = values.AboutId,
                Address = values.Address,
                CompleteProject = values.CompleteProject,
                CvUrl = values.CvUrl,
                DateOfBirth = values.DateOfBirth,
                Description = values.Description,
                CoverImageUrl= values.CoverImageUrl,
                Email = values.Email,
                Name = values.Name,
                Phone = values.Phone,
                ZipCode = values.ZipCode

            };
        }
    }
}
