using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}