using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Dto.SkillDtos
{
    public class UpdateSkillDto
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int Progress { get; set; }
    }
}
