using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces;

namespace TinyCollege.Data.Models
{
    public class Student : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public int? AdvisoryId { get; set; }
        public Advisory Advisory { get; set; }
    }
}