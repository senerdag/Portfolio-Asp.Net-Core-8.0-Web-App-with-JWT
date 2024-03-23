using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.SkillCommands
{
    public class RemoveSkillCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveSkillCommand(int id)
        {
            Id = id;
        }
    }
}
