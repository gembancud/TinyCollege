using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Interfaces
{
    public interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }

        int? DepartmentId { get; set; }

        int? AdvisoryId { get; set; }
    }
}
