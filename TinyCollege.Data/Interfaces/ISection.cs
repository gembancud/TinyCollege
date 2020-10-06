using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface ISection
    {
        int SectionId { get; set; }
        string Name { get; set; }

        int ScheduleId { get; set; }

        int ProfessorId { get; set; }

        int CourseId { get; set; }
    }
}
