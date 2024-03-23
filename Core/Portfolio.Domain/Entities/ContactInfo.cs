using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Icon { get; set; }
    }
}
