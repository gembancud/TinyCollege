using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Models
{
    public class Professor: IProfessor
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }

        public ICollection<Professorship> Professorships { get; set; }

        public ICollection<Section> Sections { get; set; }

        public ICollection<Advisory> Advisories { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Tenure> Tenures { get; set; }

        public ICollection<ProfessorContract> ProfessorContracts { get; set; }
    }
}