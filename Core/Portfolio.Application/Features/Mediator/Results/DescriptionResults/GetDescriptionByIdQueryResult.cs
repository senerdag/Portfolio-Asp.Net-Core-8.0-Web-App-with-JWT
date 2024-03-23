using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Results.DescriptionResults
{
    public class GetDescriptionByIdQueryResult
    {
        public int DescriptionId { get; set; }
        public string Name { get; set; }
        public string MainDescription { get; set; }
    }
}
