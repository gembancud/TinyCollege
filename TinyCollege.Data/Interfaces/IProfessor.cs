using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface IProfessor
    {
        int ProfessorId { get; set; }
        string Name { get; set; }
    }
}
