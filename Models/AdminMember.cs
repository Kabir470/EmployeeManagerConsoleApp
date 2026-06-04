using EmPower.Abstract;
using EmPower.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Models
{
    public class AdminMember: EmployeeBase, IDocumentAdminAccess
    {
        public AdminMember(int id, string? name, int salary, string? department, string? position)
            : base(id, name, salary, department, position)
        {
        }

        public override void CalculateSalary(int employeeID)
        {
            Console.WriteLine($" {Name} salary: {Salary} + Admin allowance: {Salary / 5}");
        }

        public override string GetRole()
        {
            return "Admin";
        }

        public void CreateDocument() => Console.WriteLine($"{Name} created a document.");
        public void UpdateDocument() => Console.WriteLine($"{Name} updated a document.");
        public void DeleteDocument() => Console.WriteLine($"{Name} deleted a document.");
        public void ReadDocument() => Console.WriteLine($"{Name} read a document.");
    }
}
