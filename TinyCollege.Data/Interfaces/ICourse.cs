using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface ICourse
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }
    }
}
