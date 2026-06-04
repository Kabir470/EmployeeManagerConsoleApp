using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Interfaces
{
    public interface IEmployee
    {
        int EmployeeID { get; set; }
        string? Name { get; set; }
        string? Department { get; set; }
        string? Position { get; set; }
        string GetRole();
    }
}
