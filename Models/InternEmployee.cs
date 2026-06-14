using EmPower.Abstract;
using EmPower.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Models
{
    internal class InternEmployee : EmployeeBase, IEmployee, IDocumentEmployeeAccess
    {
        public InternEmployee(int id, string? name, int salary, string? department, string? position)
            : base(id, name, salary, department, position)
        {
        }
       
        public override string GetRole()
        {
            return "Intern";
        }

        public override void CalculateSalary(int internID)
        {
            Console.WriteLine($" {Name} salary: {Salary} (Interns receive a fixed stipend)");
        }
        public void ReadDocument() => Console.WriteLine($"{Name} Intern read a document.");
    }
}
