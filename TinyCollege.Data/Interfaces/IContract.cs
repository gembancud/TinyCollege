using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface IContract
    {
        int ContractId { get; set; }
        string Type { get; set; }
    }
}
