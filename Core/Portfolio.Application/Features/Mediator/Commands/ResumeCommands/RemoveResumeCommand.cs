using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.ResumeCommands
{
    public class RemoveResumeCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveResumeCommand(int id)
        {
            Id = id;
        }
    }
}
