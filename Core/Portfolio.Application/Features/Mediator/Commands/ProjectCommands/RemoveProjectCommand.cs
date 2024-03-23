using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.ProjectCommands
{
    public class RemoveProjectCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveProjectCommand(int id)
        {
            Id = id;
        }
    }
}
