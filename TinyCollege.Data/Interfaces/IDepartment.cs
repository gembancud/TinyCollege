using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface IDepartment
    {
        int DepartmentId { get; set; }
        string Name { get; set; }

        int SchoolId { get; set; }
    }
}
