﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces;

namespace TinyCollege.Data.Models
{
    public class Course: ICourse
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        public ICollection<Section> Sections { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}