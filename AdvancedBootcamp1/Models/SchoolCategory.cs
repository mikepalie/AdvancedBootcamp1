using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models
{
    public class SchoolCategory
    {
        public SchoolCategory()
        {
            Schools = new HashSet<School>();
        }
        public int SchoolCategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<School> Schools { get; set; }

    }
}