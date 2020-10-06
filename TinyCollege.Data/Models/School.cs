using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces;

namespace TinyCollege.Data.Models
{
    public class School: ISchool
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }

        public int DeanId { get; set; }
        public Professor Dean { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}