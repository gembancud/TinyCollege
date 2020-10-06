using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface IEnrollment
    {
        int EnrollmentId { get; set; }

        int StudentId { get; set; }

        int SectionId { get; set; }
    }
}
