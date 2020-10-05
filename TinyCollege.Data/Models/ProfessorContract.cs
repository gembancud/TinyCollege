using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models
{
    public class ProfessorContract
    {
        public int ProfessorContractId { get; set; }
        public bool isActive { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}