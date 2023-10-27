using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models.Dtos
{
    public class AssignProjectDto
    {
        public int StudentId { get; set; }
        public List<int> projectIds { get; set; }
    }
}