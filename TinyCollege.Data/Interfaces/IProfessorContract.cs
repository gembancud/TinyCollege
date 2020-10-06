using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface IProfessorContract
    {
        public int ProfessorContractId { get; set; }
        public bool isActive { get; set; }

        public int ProfessorId { get; set; }

        public int ContractId { get; set; }
    }
}
