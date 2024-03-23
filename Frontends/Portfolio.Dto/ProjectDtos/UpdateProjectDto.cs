using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Dto.ProjectDtos
{
    public class UpdateProjectDto
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
