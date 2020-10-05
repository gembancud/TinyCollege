using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public string Type { get; set; }

        public ICollection<ProfessorContract> ProfessorContracts { get; set; }
    }
}