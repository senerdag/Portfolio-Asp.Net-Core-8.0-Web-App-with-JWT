using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.SkillCommands
{
    public class UpdateSkillCommand:IRequest
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int Progress { get; set; }
    }
}
