﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces;

namespace TinyCollege.Data.Models
{
    public class Advisory: IAdvisory
    {
        public int AdvisoryId { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}