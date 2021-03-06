﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces;

namespace TinyCollege.Data.Models
{
    public class Section: ISection
    {
        public int SectionId { get; set; }
        public string Name { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}