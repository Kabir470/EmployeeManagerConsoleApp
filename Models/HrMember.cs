using EmPower.Abstract;
using EmPower.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Models
{
    public class HrMember :EmployeeBase, IDocumentAdminAccess
    {
        public HrMember(int id, string? name, int salary, string? department, string? position)
            : base(id, name, salary, department, position)
        {
        }
        public override void CalculateSalary(int employeeID)
        {
            Console.WriteLine($" {Name} salary: {Salary} + HR allowance: {Salary / 10}");
        }
        public override string GetRole()
        {
            return "HR";
        }
        public void CreateDocument() => Console.WriteLine($"{Name} HR created a document.");
        public void UpdateDocument() => Console.WriteLine($"{Name} HR updated a document.");
        public void DeleteDocument() => Console.WriteLine($"{Name} HR deleted a document.");
        public void ReadDocument() => Console.WriteLine($"{Name} HR read a document.");
    }
}
