using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        public ICollection<Section> Sections { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}