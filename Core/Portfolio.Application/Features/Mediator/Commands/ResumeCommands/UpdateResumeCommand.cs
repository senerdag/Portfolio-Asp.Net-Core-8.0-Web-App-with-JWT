using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.ResumeCommands
{
    public class UpdateResumeCommand:IRequest
    {
        public int ResumeId { get; set; }
        public string OnYears { get; set; }
        public string Title { get; set; }
        public string University { get; set; }
        public string Description { get; set; }
        public string CvUrl { get; set; }

    }
}
