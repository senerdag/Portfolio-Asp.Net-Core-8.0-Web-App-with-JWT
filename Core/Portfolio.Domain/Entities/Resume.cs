using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public string OnYears { get; set; }
        public string Title { get; set; }
        public string University { get; set; }
        public string Description { get; set; }
        public string CvUrl { get; set; }

    }
}
