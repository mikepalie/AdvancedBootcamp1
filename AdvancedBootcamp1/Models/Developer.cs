using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvancedBootcamp1.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Range(0,100000, ErrorMessage = "Salary must be less than 100000")]
        public decimal Salary { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "1/1/2023",
         ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime Birthday { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}