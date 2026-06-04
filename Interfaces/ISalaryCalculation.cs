using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Interfaces
{
    public interface ISalaryCalculation
    {
        void CalculateSalary(int employeeID);
        int CalculateBonus(int employeeID);
    }
}
