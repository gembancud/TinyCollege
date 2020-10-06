using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces;

namespace TinyCollege.Data.Models
{
    public class Contract: IContract
    {
        public int ContractId { get; set; }
        public string Type { get; set; }

        public ICollection<ProfessorContract> ProfessorContracts { get; set; }
    }
}