using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.DescriptionCommands
{
    public class CreateDescriptionCommand:IRequest
    {
        public string Name { get; set; }
        public string MainDescription { get; set; }
    }
}
