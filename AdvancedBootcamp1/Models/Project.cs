using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}