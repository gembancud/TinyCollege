﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces;

namespace TinyCollege.Data.Models
{
    public class ProfessorContract: IProfessorContract
    {
        public int ProfessorContractId { get; set; }
        public bool isActive { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}