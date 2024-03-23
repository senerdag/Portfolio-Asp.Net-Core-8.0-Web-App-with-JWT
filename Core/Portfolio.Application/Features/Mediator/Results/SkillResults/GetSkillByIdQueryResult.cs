using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Mediator.Results.SkillResults
{
    public class GetSkillByIdQueryResult
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int Progress { get; set; }
    }
}
