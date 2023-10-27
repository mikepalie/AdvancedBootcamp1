using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models.Dtos
{
    public class StudentDto
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Project> Projects { get; set; }
    }
}