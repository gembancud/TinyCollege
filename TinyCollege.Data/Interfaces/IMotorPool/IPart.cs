using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces.IMotorPool
{
    public interface IPart
    {
         int PartId { get; set; }
         string Name { get; set; }
         int CurrentAmount { get; set; }
         int MinimumLevel { get; set; }

    }
}
