using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Commands.AboutCommands
{
    public class CreateAboutCommand:IRequest
    {
        public string Description { get; set; }
		public string CoverImageUrl { get; set; }

		public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompleteProject { get; set; }
        public string CvUrl { get; set; }
    }
}
