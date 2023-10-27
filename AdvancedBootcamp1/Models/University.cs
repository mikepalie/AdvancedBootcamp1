using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models
{
    public class University
    {
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Alpha_two_code { get; set; }
        public string Country { get; set; }
        public string Province  { get; set; }

        public ICollection<Domain> Domains { get; set; }
        public ICollection<WebPage> WebPages { get; set; }





    }
}