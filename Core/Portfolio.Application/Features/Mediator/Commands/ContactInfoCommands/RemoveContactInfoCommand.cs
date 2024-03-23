using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.ContactInfoCommands
{
    public class RemoveContactInfoCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveContactInfoCommand(int id)
        {
            Id = id;
        }
    }
}
