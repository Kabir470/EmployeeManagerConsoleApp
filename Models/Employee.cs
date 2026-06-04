using EmPower.Abstract;
using EmPower.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Models
{
    public class Employee: EmployeeBase, IDocumentEmployeeAccess
    {
        public Employee(int id, string? name, int salary, string? department, string? position)
            : base(id, name, salary, department, position)
        {
        }
        public override void CalculateSalary(int employeeID)
        {
            Console.WriteLine($" {Name} salary: {Salary}");
        }
        public override string GetRole()
        {
            return "Employee";
        }
        public void ReadDocument() => Console.WriteLine($"{Name} Employee read a document.");
    }
}
