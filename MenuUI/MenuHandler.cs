using EmPower.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.MenuUI
{
    public class MenuHandler
    {
        private EmployeeService empService;

        public MenuHandler(EmployeeService empService)
        {
            this.empService = empService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n===== EMPLOYEE MANAGER =====");
                Console.WriteLine("1. Hire Employee");
                Console.WriteLine("2. Fire Employee");
                Console.WriteLine("3. List All Employees");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": HireMenu(); break;
                    case "2": FireMenu(); break;
                    case "3": empService.ListAll(); break;
                    case "4": return;
                    default: Console.WriteLine("❌ Invalid choice!"); break;
                }
            }
        }

        private void HireMenu()
        {
            Console.Write("Name: ");
            string? name = Console.ReadLine();

            Console.Write("Role (Admin/HR/Employee): ");
            string? role = Console.ReadLine();

            Console.Write("Salary: ");
            int salary = int.Parse(Console.ReadLine());

            Console.Write("Department: ");
            string? dept = Console.ReadLine();

            Console.Write("Position: ");
            string? pos = Console.ReadLine();

            empService.HireEmployee(role, name, salary, dept, pos);
        }

        private void FireMenu()
        {
            Console.Write("Enter Employee ID to fire: ");
            int id = int.Parse(Console.ReadLine());
            empService.FireEmployee(id);
        }
    }
}
