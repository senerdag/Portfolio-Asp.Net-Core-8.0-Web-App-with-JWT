using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.ServiceCommands
{
    public class CreateServiceCommand:IRequest
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
