using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces;

namespace TinyCollege.Data.Models
{
    public class Department: IDepartment
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public ICollection<Tenure> Tenures { get; set; }

        public ICollection<Professorship> Professorships { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Advisory> Advisories { get; set; }
    }
}