using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.DescriptionCommands
{
    public class RemoveDescriptionCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveDescriptionCommand(int id)
        {
            Id = id;
        }
    }
}
