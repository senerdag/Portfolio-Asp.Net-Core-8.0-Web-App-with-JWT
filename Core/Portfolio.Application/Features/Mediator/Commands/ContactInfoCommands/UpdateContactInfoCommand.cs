using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.ContactInfoCommands
{
    public class UpdateContactInfoCommand:IRequest
    {
        public int ContactInfoId { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Icon { get; set; }
    }
}
