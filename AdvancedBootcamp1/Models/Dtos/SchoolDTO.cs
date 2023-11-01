using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models.Dtos
{
    public class SchoolDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CatId { get; set; }
        public List<int> DepsId { get; set; }
    }
}