using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models.Dtos
{
    public class UniversityDto
    {
        public string Name { get; set; }
        public string Alpha_two_code { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public List<string> Domains { get; set; }
        public List<string> WebPages { get; set; }
    }
}