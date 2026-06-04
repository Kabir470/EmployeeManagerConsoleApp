using EmPower.Abstract;
using EmPower.Models;
using EmPower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Services
{
    public class EmployeeService
    {
        private EmployeeRepository repo;

        public EmployeeService(EmployeeRepository repo)
        {
            this.repo = repo;
        }

        public void HireEmployee(string? role, string? name, int salary, string? dept, string? pos)
        {
            int id = repo.GenerateID();

            EmployeeBase emp = role switch
            {
                "Admin" => new AdminMember(id, name, salary, dept, pos),
                "HR" => new HrMember(id, name, salary, dept, pos),
                "Employee" => new Employee(id, name, salary, dept, pos),
                _ => null
            };

            if (emp == null) { Console.WriteLine("❌ Invalid role!"); return; }
            repo.AddEmployee(emp);
        }

        public void FireEmployee(int id) => repo.RemoveEmployee(id);
        public void ListAll()
        {
            var all = repo.GetAllEmployees();
            if (all.Count == 0) { Console.WriteLine("No employees found."); return; }
            foreach (var emp in all)
                emp.PrintDetails();
        }
    }
}
