using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface IAdvisory
    {
        int AdvisoryId { get; set; }

        int DepartmentId { get; set; }

        int ProfessorId { get; set; }

        int StudentId { get; set; }
    }
}
