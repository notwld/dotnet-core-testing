using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Testing.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseShortName { get; set; }
    }
}
