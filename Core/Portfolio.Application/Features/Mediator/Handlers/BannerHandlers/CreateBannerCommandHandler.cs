using MediatR;
using Portfolio.Application.Features.Mediator.Commands.BannerCommands;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler:IRequestHandler<CreateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Banner
            {
                CoverImageUrl = request.CoverImageUrl,
                Description = request.Description,
                Title = request.Title,
                SideTitle = request.SideTitle

            });

        }
    }
}
