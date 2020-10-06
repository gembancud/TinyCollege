using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface ITenure
    {
        int TenureId { get; set; }
        int Succession { get; set; }

        int ProfessorId { get; set; }

        int DepartmentId { get; set; }
    }
}
