using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int Progress { get; set; }
    }
}
