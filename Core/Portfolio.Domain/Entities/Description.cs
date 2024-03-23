using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Description
    {
        public int DescriptionId { get; set; }
        public string Name { get; set; }
        public string MainDescription { get; set; }
    }
}
