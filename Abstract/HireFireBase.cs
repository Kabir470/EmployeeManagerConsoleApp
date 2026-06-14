using EmPower.Services;
using System;

namespace EmPower.Abstract
{
    public class HireFireBase 
    {
        private EmployeeService empService;

        // Force construction with an existing service
        public HireFireBase(EmployeeService empService)
        {
            this.empService = empService;
        }

        public void HireMenu()
        {
            Console.Write("Name: ");
            string? name = Console.ReadLine();

            Console.Write("Role (Admin/HR/Employee/Intern): ");
            string? role = Console.ReadLine();

            Console.Write("Salary: ");
            int salary = int.Parse(Console.ReadLine());

            Console.Write("Department: ");
            string? dept = Console.ReadLine();

            Console.Write("Position: ");
            string? pos = Console.ReadLine();

            empService.HireEmployee(role, name, salary, dept, pos);
        }

        public void FireMenu()
        {
            Console.Write("Enter Employee ID to fire: ");
            int id = int.Parse(Console.ReadLine());
            empService.FireEmployee(id);
        }
    }
}
