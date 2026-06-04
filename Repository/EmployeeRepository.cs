using EmPower.Abstract;
using EmPower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Repository
{
    public class EmployeeRepository
    {
        public List<EmployeeBase> employees = new List<EmployeeBase>();
        private int nextId = 1;

        public void AddEmployee(EmployeeBase emp)
        {
            employees.Add(emp);
            Console.WriteLine($"Employee added: {emp.Name} ");

        }

        public void RemoveEmployee(int employeeID)
        {
            var emp = GetByID(employeeID);
            if (emp == null) { Console.WriteLine("❌ Employee not found!"); return; }
            employees.Remove(emp);
            Console.WriteLine($"✅ {emp.Name} removed.");
        }

        private EmployeeBase GetByID(int id) => employees.FirstOrDefault(e => e.EmployeeID == id);

        public List<EmployeeBase> GetAllEmployees() => employees;

        public int GenerateID () => nextId++;
    }
}
