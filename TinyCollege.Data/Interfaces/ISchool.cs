using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface ISchool
    {
        int SchoolId { get; set; }
        string Name { get; set; }

        int DeanId { get; set; }
    }
}
