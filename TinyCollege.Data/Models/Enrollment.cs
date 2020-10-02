using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}