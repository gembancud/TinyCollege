﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }

        public ICollection<Section>? Sections { get; set; }

        public ICollection<Advisory>? Advisories { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }

        public int? ContractId { get; set; }
        public Contract? Contract { get; set; }
    }
}