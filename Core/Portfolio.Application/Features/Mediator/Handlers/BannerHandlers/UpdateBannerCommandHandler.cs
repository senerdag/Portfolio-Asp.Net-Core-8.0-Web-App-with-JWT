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
    public class UpdateBannerCommandHandler:IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BannerId);
            values.SideTitle = request.SideTitle;
            values.Description = request.Description;
            values.Title = request.Title;
            values.CoverImageUrl = request.CoverImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
