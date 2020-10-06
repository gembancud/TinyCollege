using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface IProfessorship
    {
        public int ProfessorShipId { get; set; }
        public bool isActive { get; set; }

        public int ProfessorId { get; set; }

        public int DepartmentId { get; set; }
    }
}
