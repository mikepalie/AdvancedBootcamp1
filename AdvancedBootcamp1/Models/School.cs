using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models
{
    public class School
    {
        public School()
        {
            Departments = new HashSet<Department>();
        }


        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Department> Departments { get; set; }

        public int? SchoolCategoryId { get; set; }
        public SchoolCategory SchoolCategory { get; set; }

    }
}