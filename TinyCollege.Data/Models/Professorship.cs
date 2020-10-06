using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models
{
    public class Professorship
    {
        public int ProfessorShipId { get; set; }
        public bool isActive { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}